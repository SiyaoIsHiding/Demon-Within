using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAIController : MonoBehaviour
{
    /////////////////////////////////////////////// Required Components; I know there is [RequireComponent] but I prefer this
    public NavMeshAgent navMeshAgentComp;
    public BaseEnemyStatus statusComp;
    ////////////////////////////////////////////////
    [Tooltip("This will usually be the player")]
    public GameObject target;
    [Tooltip("The half-angle which dictates when the enemy will start to rotate to face the target")]
    [Range(0, 180)]
    public float faceTargetLeeway;
    public float rotationSpeed;

    public Goon_AttackState attackState = new Goon_AttackState();
    public Goon_PassiveState passiveState = new Goon_PassiveState();
    private Abstract_EnemyState currentState;

    private IEnumerator Start()
    {
        ChangeState(passiveState);

        yield return new WaitForSeconds(6);

        currentState.OnAnger();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    public void ChangeState(Abstract_EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
