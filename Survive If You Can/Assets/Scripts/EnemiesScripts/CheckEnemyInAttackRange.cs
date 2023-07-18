using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UIElements;

public class CheckEnemyInAttackRange : Node
{
    private Transform transform;
    private EnemyGunInfo enemyGunInfo;
    private GameObject weapon;
    private EnemyTYPE enemyType;

    public CheckEnemyInAttackRange(Transform transform, EnemyGunInfo enemyGunInfo, GameObject weapon, EnemyTYPE enemyTYPE)
    {
        this.transform = transform;
        this.enemyGunInfo = enemyGunInfo;
        this.weapon = weapon;
        this.enemyType = enemyTYPE;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null) //If there is no target, there's nothing to attack
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (enemyType == EnemyTYPE.Ranged)
        {
            if(CheckShootingRange(directionToTarget, distanceToTarget) == true) 
            {
                state = NodeState.SUCCESS;
                return state; 
            }
        }
        else if (enemyType == EnemyTYPE.Melee)
        {
            if(CheckExplosionRange(distanceToTarget) == true)
            {
                state = NodeState.SUCCESS;
                return state;
            }
        }

        state = NodeState.FAILURE;
        return state;

    }


    private bool CheckShootingRange(Vector3 directionToTarget, float distanceToTarget)
    {
      
        //Check if the target is in the gun range
        if( enemyGunInfo.gunRange >= distanceToTarget)
        {
            //Check if other colleages or walls are between it and the player
            if((!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, enemyGunInfo.obstruction)) && (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, enemyGunInfo.colleagues)))
            {
                return true;
            }
        }

        return false;

    }

    private bool CheckExplosionRange(float distanceToTarget)
    {
        if(enemyGunInfo.bombRange >= distanceToTarget)
        {
            return true;
        }
        return false;
    }


}
