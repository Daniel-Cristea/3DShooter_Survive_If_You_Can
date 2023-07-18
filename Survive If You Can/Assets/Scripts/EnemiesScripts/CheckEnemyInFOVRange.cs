using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UIElements;

public class CheckEnemyInFOVRange : Node
{
    private Transform transform;
    private EnemyInfo enemyInfo;
    private EnemyGunInfo enemyGunInfo;

    public CheckEnemyInFOVRange(Transform transform, EnemyInfo enemyInfo, EnemyGunInfo enemyGunInfo)
    {
        this.transform = transform;
        this.enemyInfo = enemyInfo;
        this.enemyGunInfo = enemyGunInfo;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyInfo.fovRange, enemyInfo.player);

            if (colliders.Length > 0)
            {
                Transform targetPosition = colliders[0].transform;
                Vector3 directionToTarget = (targetPosition.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, directionToTarget) < enemyInfo.viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, targetPosition.position);
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, enemyGunInfo.obstruction))
                    {
                        parent.parent.SetData("target", colliders[0].transform);
                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
                
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
