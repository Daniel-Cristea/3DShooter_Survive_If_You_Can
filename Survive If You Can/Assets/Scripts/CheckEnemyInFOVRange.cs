using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UIElements;

public class CheckEnemyInFOVRange : Node
{
    private Transform transform;
    private EnemyInfo enemyInfo;

    public CheckEnemyInFOVRange(Transform transform, EnemyInfo enemyInfo)
    {
        this.transform = transform;
        this.enemyInfo = enemyInfo;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyInfo.fovRange, enemyInfo.player);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
