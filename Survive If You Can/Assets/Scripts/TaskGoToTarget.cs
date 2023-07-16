using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class TaskGoToTarget : Node
{

    Transform transform;
    [SerializeField] private NavMeshAgent agent;
    EnemyGunInfo enemyGunInfo;
    private EnemyInfo enemyInfo;

    public TaskGoToTarget(Transform transform, NavMeshAgent agent, EnemyGunInfo enemyGunInfo, EnemyInfo enemyInfo)
    {
        this.transform = transform;
        this.agent = agent;
        this.enemyGunInfo = enemyGunInfo;
        this.enemyInfo = enemyInfo;
    }

    public override NodeState Evaluate()
    {
        Transform targetTransform = (Transform)GetData("target");

        Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

        if ((Vector3.Distance(transform.position, targetTransform.position) > enemyInfo.fovRange ) || (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, enemyGunInfo.obstruction))){
            agent.isStopped= true;
            state = NodeState.FAILURE;
            return state;
        }
        agent.isStopped = false;
        agent.SetDestination(targetTransform.position);

        state = NodeState.SUCCESS;
        return state;
    }


}
