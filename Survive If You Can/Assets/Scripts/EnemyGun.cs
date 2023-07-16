using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private EnemyGunInfo enemyGunInfo;
    [SerializeField] private GameObject BulletSpawnPoint;
    private Transform targetTransform;
    private float damage;
    private float range;
    private int allBullets;
    private int magazineCapacity;
    private float reloadingTime;
    private float gunDelay;
    private float LastFired;
    private int magazineBullets;
    private bool canShoot;

    //Vector3 correctionAngle = new Vector3(0, 0, 90);

    // Start is called before the first frame update
    void Start()
    {
        InitalizeVariables();
    }


    public void ShootingRequest(Transform targetTransform)
    {
        //The gun must face the target
        
        transform.parent.LookAt(targetTransform.position);

        //If 1. The gun has bullets, 2. The delay time between shots passed and 3. The gun is not reloading
        if ((allBullets > 0) && (Time.time - LastFired > gunDelay) && canShoot)
        {
            LastFired = Time.time;
            Shoot(); //Debug.Log("YES");
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, range))
        {
            if (hit.transform.tag == "Player")
            {
                hit.transform.gameObject.GetComponent<TargetPlayer>().TakeDamage(damage);
            }
        }

        magazineBullets--;

        if (magazineBullets == 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        magazineBullets = magazineCapacity;
        canShoot = false;

        yield return new WaitForSeconds(reloadingTime);

        canShoot = true;
    }


    private void InitalizeVariables()
    {
        damage = enemyGunInfo.gunDamage;
        range = enemyGunInfo.gunRange;
        magazineCapacity = enemyGunInfo.gunMagazineCapacity;
        allBullets = enemyGunInfo.allBullets;
        reloadingTime = enemyGunInfo.gunReloadingTime;
        gunDelay = enemyGunInfo.gunDelay;
        LastFired = 0.0f;
        magazineBullets = magazineCapacity;
        canShoot = true;
    }

}
