using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskAttack : Node
{

    private Transform transform;
    private GameObject weapon;
    private EnemyTYPE enemyType;
    private NavMeshAgent agent;
    private EnemyInfo enemyInfo;

    public TaskAttack(Transform transform, GameObject weapon, EnemyTYPE enemyTYPE, NavMeshAgent agent, EnemyInfo enemyInfo) 
    {
        this.transform = transform;
        this.weapon = weapon;
        this.enemyType = enemyTYPE;
        this.agent = agent;
        this.enemyInfo = enemyInfo;
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
        agent.speed = enemyInfo.chasingSpeed_Melee/2;
        weapon.GetComponent<Bomb>().DetonateBomb();
       // transform.gameObject.GetComponent<Bomb>().Explode(); ERROR HERE 
    }


}
