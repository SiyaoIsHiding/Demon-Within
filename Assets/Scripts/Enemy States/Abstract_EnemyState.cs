using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_EnemyState
{
    protected BaseEnemyAIController AIController;

    public virtual void OnEnter(BaseEnemyAIController controller)
    {
        AIController = controller;
    }
    public virtual void OnUpdate()
    {
    }
    public virtual void OnAnger()
    {

    }
    public virtual void OnExit()
    {
    }
}
