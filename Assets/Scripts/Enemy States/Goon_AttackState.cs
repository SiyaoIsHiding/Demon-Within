using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_AttackState : Abstract_EnemyState
{
    private GameObject goonHitbox;
    private Transform hitboxSpawnLocation;
    private float hitboxLifetime;
    private float attackRange;
    private bool startedAttackLoop = false;

    // The basic idea attack pattern I'm thinking of now is hit -- hit-hit ---- hit -- hit-hit ---- etc.
    public override void OnEnter(BaseEnemyAIController controller)
    {
        base.OnEnter(controller);

        goonHitbox = controller.hitboxes.hitboxes[0];
        hitboxSpawnLocation = ((GoonEnemyAIController)controller).attackSocket;
        hitboxLifetime = ((GoonEnemyAIController)controller).attackHitboxDuration;
        attackRange = ((GoonEnemyAIController)controller).attackRange;
    }

    public override void OnUpdate()
    {
        // Move to target
        AIController.navMeshAgentComp.SetDestination(AIController.target.transform.position);

        // Face the target
        Vector3 lineToTarget = AIController.target.transform.position - AIController.transform.position;
        float angleToTarget = Vector3.Angle(lineToTarget, AIController.transform.forward);
        if (angleToTarget >= AIController.faceTargetLeeway)
        {
            AIController.transform.rotation = Quaternion.LookRotation(lineToTarget);
        }

        // Start attacking if the player is in range
        if (TargetInRange() && !startedAttackLoop)
        {
            AIController.StartCoroutine(AttackLoop());
        }
        else if (!TargetInRange() && startedAttackLoop)
        {
            startedAttackLoop = false;
            AIController.StopAllCoroutines();
        }
    }

    private bool TargetInRange()
    {
        return Vector3.Distance(AIController.target.transform.position, AIController.gameObject.transform.position) < attackRange;
    }

    private IEnumerator AttackLoop()
    {
        startedAttackLoop = true;

        HitOnce();
        yield return new WaitForSeconds(((GoonEnemyAIController)AIController).firstHitDelay);

        // Combo hit
        HitOnce();
        yield return new WaitForSeconds(((GoonEnemyAIController)AIController).comboHitDelay);
        HitOnce();

        yield return new WaitForSeconds(((GoonEnemyAIController)AIController).attackLoopDelay);

        startedAttackLoop = false;
        // Loop
        AIController.StartCoroutine(AttackLoop());
    }

    private void HitOnce()
    {
        GameObject newHitbox = Object.Instantiate(goonHitbox, hitboxSpawnLocation.position, hitboxSpawnLocation.rotation);
        Object.Destroy(newHitbox, hitboxLifetime);
    }
}
