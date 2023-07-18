using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;


    void Awake()
    {
        Destroy(gameObject, playerInfo.bulletLife);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
