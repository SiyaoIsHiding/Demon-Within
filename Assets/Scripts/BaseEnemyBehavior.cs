using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private NavMeshAgent navMeshAgentComp;

    void Start()
    {
        navMeshAgentComp = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgentComp.SetDestination(target.transform.position);
    }
}
