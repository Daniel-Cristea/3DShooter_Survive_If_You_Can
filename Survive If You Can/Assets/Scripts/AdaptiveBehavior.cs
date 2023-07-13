using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class AdaptiveBehavior : BehaviorTree.Tree
{
    public UnityEngine.Transform[] waypoints;
    [SerializeField] private EnemyInfo enemyInfo;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            //new Sequence(new List<Node>
            //{
            //    new CheckEnemyInAttackRange(transform),
            //    new TaskAttack(transform),
            //}),
           /* new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }), */
           new TaskPatrol(waypoints, transform, enemyInfo),
        });

        return root;
    }
}
