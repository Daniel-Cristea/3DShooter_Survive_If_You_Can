using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Text magazineBulletsText;
    [SerializeField] private Text totalBulletsText;
    [SerializeField] private Image ReloadingImage;
    [SerializeField] private Image RButtonImage;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem muzzleFlash;

    [SerializeField] private Camera fpsCamera;

    private float damage;
    private float range;
    private int magazineBullets;
    private int allBullets;
    private int magazineCapacity;
    private float reloadingTime;
    private float gunDelay;
    private float LastFired;
    private bool canUseGun = true;

    // Start is called before the first frame update
    void Start()
    {
        InitalizeVariables();
        WriteOnScreen();
    }

    // Update is called once per frame
    void Update()
    {
        WriteOnScreen();

        if (canUseGun)
        { // a player can not use the gun while it's reloading
            GunInteractions();
        }
    }

    private void GunInteractions()
    {
        if (Input.GetButton("Fire1") && !EndGameMenu.gameIsPaused)
        {
            if (magazineBullets > 0 && (Time.time - LastFired > gunDelay))
            {
                LastFired = Time.time;
                Shoot();
            }

        }
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        //var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * playerInfo.bulletSpeed;

        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy") { 
            hit.transform.gameObject.GetComponent<TargetEnemy>().TakeDamage(damage);
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
        if (magazineBullets == magazineCapacity) // If the magazine is full, you can't refill it 
            yield break;


        canUseGun = false; // the gun can't be used util the end of the reload
        RButtonImage.gameObject.SetActive(false); //R button on the screen will disappear
        ReloadingImage.gameObject.SetActive(true); //reloading text appears on the screen

        yield return new WaitForSeconds(reloadingTime);
        if (allBullets > 0)
        {
            allBullets += magazineBullets;

            if (allBullets / magazineCapacity > 0)
            {
                magazineBullets = magazineCapacity;
                allBullets -= magazineCapacity;
            }
            else
            {
                magazineBullets = allBullets;
                allBullets = 0;
            }
        }

        canUseGun = true;
        ReloadingImage.gameObject.SetActive(false); //reloading text disappears 

    }

    private void InitalizeVariables()
    {
        damage = playerInfo.gunDamage;
        range = playerInfo.gunRange;
        magazineCapacity = playerInfo.gunMagazineCapacity;
        magazineBullets = magazineCapacity;
        allBullets = playerInfo.allBullets;
        reloadingTime = playerInfo.gunReloadingTime;
        gunDelay = playerInfo.gunDelay;
        LastFired = 0.0f;
    }

    private void WriteOnScreen()
    {
        magazineBulletsText.text = "Bullets: " + magazineBullets + "/" + magazineCapacity;
        totalBulletsText.text = "Total Bullets: " + allBullets;

        if ((magazineBullets <= magazineCapacity / 5) && canUseGun)
            RButtonImage.gameObject.SetActive(true); //R = reload button on the screen will apear if you have less than 20% ammo
    }
}
