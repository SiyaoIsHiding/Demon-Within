using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_AttackState : Abstract_EnemyState
{
    public override void OnUpdate()
    {
        // Move to target
        AIController.navMeshAgentComp.SetDestination(AIController.target.transform.position);

        // Face the target
        Vector3 lineToTarget = AIController.target.transform.position - AIController.transform.position;
        float angleToTarget = Vector3.Angle(lineToTarget, AIController.transform.forward);
        if (angleToTarget >= AIController.faceTargetLeeway)
        {
            AIController.transform.rotation = Quaternion.RotateTowards(AIController.transform.rotation, AIController.target.transform.rotation, AIController.rotationSpeed * Time.deltaTime);
        }
    }
}
