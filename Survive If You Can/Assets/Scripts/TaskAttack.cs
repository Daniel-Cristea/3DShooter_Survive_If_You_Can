using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskAttack : Node
{

    private Transform transform;
    private GameObject weapon;
    private EnemyTYPE enemyType;

    public TaskAttack(Transform transform, GameObject weapon, EnemyTYPE enemyTYPE) 
    {
        this.transform = transform;
        this.weapon = weapon;
        this.enemyType = enemyTYPE;
    }

    public override NodeState Evaluate()
    {
        if(enemyType == EnemyTYPE.Ranged)
        {
            Shoot();
        }
        else if(enemyType == EnemyTYPE.Melee)
        {
            ThrowBomb();
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

    private void Shoot()
    {
        Transform target = (Transform)GetData("target");
        transform.LookAt(target.position);
        weapon.GetComponent<EnemyGun>().ShootingRequest(target);
    }

    private void ThrowBomb()
    {
        
    }


}
