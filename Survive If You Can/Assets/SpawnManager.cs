using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public UnityEngine.Transform[] spawnPoints;
    [SerializeField] private GameObject MeleeEnemy;
    [SerializeField] private GameObject RangedEnemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(EnemyTYPE enemyType)
    {

        StartCoroutine(Spawn(enemyType));
          
    }


    IEnumerator Spawn(EnemyTYPE enemyType)
    {
        yield return new WaitForSeconds(1.0f);

        if (enemyType == EnemyTYPE.Melee)
            Instantiate(MeleeEnemy, spawnPoints[0]);
        else if (enemyType == EnemyTYPE.Ranged)
            Instantiate(RangedEnemy, spawnPoints[0]);
    }

}
