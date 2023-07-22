using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{

    public UnityEngine.Transform[] spawnPoints;
    [SerializeField] private GameObject MeleeEnemy;
    [SerializeField] private GameObject RangedEnemy;

    [SerializeField] private GameObject nextWaveCanvas;
    [SerializeField] private Text nextWaveText;

    public UnityEngine.Transform[] spawnPoints_Room0_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room0_Ranged;
    public UnityEngine.Transform[] spawnPoints_Room1_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room1_Ranged;
    public UnityEngine.Transform[] spawnPoints_Room2_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room2_Ranged;
    public UnityEngine.Transform[] spawnPoints_Room3_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room3_Ranged;
    public UnityEngine.Transform[] spawnPoints_Room4_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room4_Ranged;
    public UnityEngine.Transform[] spawnPoints_Room5_Creeper;
    public UnityEngine.Transform[] spawnPoints_Room5_Ranged;

    int roomIndexCreeper = 0;
    int roomIndexRanged = 0;
    float timeRemaining = 0f;

    private void Start()
    {
        SetSpawningTimer();
    }

    private void Update()
    {
        SpawningCountdown();
        UpdateCountdownInterface();
    }

    private void SetSpawningTimer()
    {

        timeRemaining = UnityEngine.Random.Range(60, 120);
        
    }

    private void SpawningCountdown()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SetSpawningTimer();
            PopulateMap();
        }
    }

    private void UpdateCountdownInterface()
    {
        if (timeRemaining <= 8)
        {
            nextWaveText.text = "Next Wave \r\n in " + (int)timeRemaining + "...";
            nextWaveCanvas.SetActive(true);
        }
        else
        {
            nextWaveCanvas.SetActive(false);
        }
    }

    private void PopulateMap()
    {
        for(int i = 0; i < 6; i++)
        {
            SpawnRequest(EnemyTYPE.Ranged, i);
            SpawnRequest(EnemyTYPE.Melee, i);
        }
    }

    private void SpawnRequest(EnemyTYPE enemyType, int roomIndex)
    {
        Transform spawnPoint = getSpawnPoint(enemyType, roomIndex);
        Spawn(enemyType, spawnPoint);
    }

    public void ReSpawnRequest(EnemyTYPE enemyType, int currentRoomNumber)
    {
        int roomIndex = getRoomIndex(enemyType, currentRoomNumber);
        Transform spawnPoint = getSpawnPoint(enemyType, roomIndex);
        StartCoroutine(ReSpawn(enemyType, spawnPoint));
    }


    IEnumerator ReSpawn(EnemyTYPE enemyType, Transform spawnPoint)
    {
        yield return new WaitForSeconds(1.0f);

        if (enemyType == EnemyTYPE.Melee)
            Instantiate(MeleeEnemy, spawnPoint);
        else if (enemyType == EnemyTYPE.Ranged)
            Instantiate(RangedEnemy, spawnPoint);
    }

    private void Spawn(EnemyTYPE enemyType, Transform spawnPoint)
    {
        if (enemyType == EnemyTYPE.Melee)
            Instantiate(MeleeEnemy, spawnPoint);
        else if (enemyType == EnemyTYPE.Ranged)
            Instantiate(RangedEnemy, spawnPoint);
    }

    private int getRoomIndex(EnemyTYPE enemyType, int currentRoomNumber)
    {
        int index = 0;
        if (enemyType == EnemyTYPE.Melee)
        {
            if(currentRoomNumber== roomIndexCreeper) //I avoid respawning an enemy in the same room
            {
                roomIndexCreeper = (roomIndexCreeper + 1) % 6;
            }
            index = roomIndexCreeper;
            roomIndexCreeper = (roomIndexCreeper + 1) % 6;
            return index;
            
        }
        else
        {
            if (currentRoomNumber == roomIndexRanged) //I avoid respawning an enemy in the same room
            {
                roomIndexRanged = (roomIndexRanged + 1) % 6;
            }
            index = roomIndexRanged;
            roomIndexRanged = (roomIndexRanged + 1) % 6;
            return index;
        }
    }

    private Transform getSpawnPoint(EnemyTYPE enemyType, int roomNumber)
    {
        int spawnPoint;
        switch (roomNumber, enemyType)
        {
            case (0, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room0_Creeper.Length);
                return spawnPoints_Room0_Creeper[spawnPoint];
            case (0, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room0_Ranged.Length);
                return spawnPoints_Room0_Ranged[spawnPoint];

            case (1, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room1_Creeper.Length);
                return spawnPoints_Room1_Creeper[spawnPoint];
            case (1, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room1_Ranged.Length);
                return spawnPoints_Room1_Ranged[spawnPoint];

            case (2, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room2_Creeper.Length);
                return spawnPoints_Room2_Creeper[spawnPoint];
            case (2, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room2_Ranged.Length);
                return spawnPoints_Room2_Ranged[spawnPoint];

            case (3, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room3_Creeper.Length);
                return spawnPoints_Room3_Creeper[spawnPoint];
            case (3, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room3_Ranged.Length);
                return spawnPoints_Room3_Ranged[spawnPoint];

            case (4, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room4_Creeper.Length);
                return spawnPoints_Room4_Creeper[spawnPoint];
            case (4, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room4_Ranged.Length);
                return spawnPoints_Room4_Ranged[spawnPoint];

            case (5, EnemyTYPE.Melee):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room5_Creeper.Length);
                return spawnPoints_Room5_Creeper[spawnPoint];
            case (5, EnemyTYPE.Ranged):
                spawnPoint = UnityEngine.Random.Range(0, spawnPoints_Room5_Ranged.Length);
                return spawnPoints_Room5_Ranged[spawnPoint];

            default:
                return spawnPoints[0];
        }
    }

}
