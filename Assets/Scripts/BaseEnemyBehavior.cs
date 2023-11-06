using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This will usually be the player")]
    private GameObject target;
    [SerializeField]
    [Tooltip("The half-angle which dictates when the enemy will start to rotate to face the target")]
    [Range(0, 180)]
    private float faceTargetLeeway;
    [SerializeField]
    private float rotationSpeed;

    private NavMeshAgent navMeshAgentComp;

    void Start()
    {
        navMeshAgentComp = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Move to target
        navMeshAgentComp.SetDestination(target.transform.position);

        // Face the target
        Vector3 lineToTarget = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(lineToTarget, transform.forward);
        if (angleToTarget >= faceTargetLeeway)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
