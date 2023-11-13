using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_PassiveState : Abstract_EnemyState
{
    public override void OnAnger()
    {
        AIController.ChangeState(AIController.attackState);
    }
}
