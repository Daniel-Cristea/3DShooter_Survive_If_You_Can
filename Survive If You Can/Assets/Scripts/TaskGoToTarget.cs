using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskGoToTarget : Node
{

    Transform transform;

    public TaskGoToTarget(Transform transform)
    {
        this.transform = transform;
    }


}
