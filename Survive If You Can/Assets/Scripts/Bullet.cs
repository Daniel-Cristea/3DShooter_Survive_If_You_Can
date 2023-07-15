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
        
      /*  if(collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<TargetEnemy>().TakeDamage(playerInfo.gunDamage);
        } */

        Destroy(gameObject);
    }
}
