using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    [SerializeField] private EnemyGunInfo enemyGunInfo;
    [SerializeField] private GameObject effectCube;
    [SerializeField] private SpawnManager spawnManager;

    private float bombRange;
    private float bombCountdownSeconds;
    private float bombDamage;
    private bool bombActivated = false;


    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        bombRange = enemyGunInfo.bombRange;
        bombCountdownSeconds = enemyGunInfo.bombCountdownSeconds;
        bombDamage = enemyGunInfo.bombDamage;
    }

    public void DetonateBomb()
    {
        if (!bombActivated) { 
            bombActivated= true;
        StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        effectCube.SetActive(true);
        yield return new WaitForSeconds(bombCountdownSeconds/3.0f);
        effectCube.SetActive(false);
        yield return new WaitForSeconds(bombCountdownSeconds / 3.0f);
        effectCube.SetActive(true);
        yield return new WaitForSeconds(bombCountdownSeconds / 3.0f);
        DamagePlayer();
        spawnManager.SpawnEnemy(EnemyTYPE.Melee);
        Destroy(transform.parent.parent.gameObject);
    }

    private void DamagePlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, enemyGunInfo.player);
        if (colliders.Length > 0)
        {
            colliders[0].transform.gameObject.GetComponent<TargetPlayer>().TakeDamage(bombDamage);
        }
    }
}
