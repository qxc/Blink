using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject droneEnemy;
    public GameObject gruntEnemy;
    public GameObject character;
    public GameObject lingEnemy;
    public GameObject tankEnemy;
    public GameObject sniperEnemy;
    public GameObject turretEnemy;
    public List<GameObject> enemies;

    public List<int> spawnEnemies;

    float bufferDistance = 4f;

    public float timer = 0f;
    float spawnPeriod = 5f;
    private float spawnDelay = 2f;
    int enemyCap = 5;
    int numEnemyTypes = 0;

	// Use this for initialization
	void Start ()
    {
        SetupSpawnEnemies();
        Invoke("SpawnEnemy2", spawnDelay);
        character = GameObject.Find("Character"); //Sets the character used for spawn tracking
        InvokeRepeating("SetSpawnEnemies", 10, 10);
        InvokeRepeating("AddSpawnEnemy", 30, 30);
    }

    void Update() {
        timer += Time.deltaTime;
    }

    public Vector2 RandomPositionNearCharacter()
    {
        Vector2 randomSpawn = Random.insideUnitCircle;
        randomSpawn.Normalize();
        randomSpawn = randomSpawn * bufferDistance;
        return new Vector2(character.transform.position.x, character.transform.position.y) + randomSpawn;
    }

    public void SetupSpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnEnemies.Add(0);
        }
    }

    public void SpawnEnemy2()
    {
        foreach (int x in spawnEnemies)
        {
            if (enemies.Count < enemyCap)
            {
                Vector2 spawnPosition = RandomPositionNearCharacter();
                if (x == 0)
                {
                    InstantiateEnemy(droneEnemy, spawnPosition);
                }
                if (x == 1)
                {
                    InstantiateEnemy(gruntEnemy, spawnPosition);
                }
                if (x == 2)
                {
                    InstantiateEnemy(turretEnemy, spawnPosition);
                }
                if (x == 3)
                {
                    InstantiateEnemy(lingEnemy, spawnPosition);
                    InstantiateEnemy(lingEnemy, spawnPosition);
                }
                if (x == 4)
                    InstantiateEnemy(tankEnemy, spawnPosition);
                if (x == 5)
                    InstantiateEnemy(sniperEnemy, spawnPosition);
                //}
            }
        }
        SetEnemyCap();
        Invoke("SpawnEnemy2", spawnPeriod);
    }

    public void SetSpawnEnemies()
    {
        /*
         * At various time increments, add or replace numbers in the array. So at any time there's an array 
         * of numbers which determine which units are spawned. Is there a way to do this ~randomly?
         * Goal is steady increase in numbers which determine how difficult enemies are spawned
         */

        int index = Random.Range(0, spawnEnemies.Count);
        spawnEnemies[index]++;
    }

    public void AddSpawnEnemy()
    {
        spawnEnemies.Add(0);
    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawning Enemy");
        //Debug.Log(enemies.Count + " - count and cap " + enemyCap);
        while (enemies.Count < enemyCap) {
            //Debug.Log(enemyCap);
            //Debug.Log("Below cap");
            int enemyType = Random.Range(0, numEnemyTypes);
            //Chooses a random location within a certain distance of the player and spawns there
            //Debug.Log(randomSpawn);
            
            //float numEnemySpawn = Mathf.Min(3f, timer / 60f);
            //for (int i = 0; i < numEnemySpawn; i++)
            //{
            Vector2 spawnPosition = RandomPositionNearCharacter();
            if (enemyType == 0)
            {
                InstantiateEnemy(droneEnemy, spawnPosition);
            }
            if (enemyType == 1)
            {
                InstantiateEnemy(gruntEnemy, spawnPosition);
            }
            if (enemyType == 2)
            {
                InstantiateEnemy(turretEnemy, spawnPosition);
            }
            if (enemyType == 3)
                {
                    InstantiateEnemy(lingEnemy, spawnPosition);
                    InstantiateEnemy(lingEnemy, spawnPosition);
                }
                if (enemyType == 4)
                    InstantiateEnemy(tankEnemy, spawnPosition);
                if (enemyType == 5)
                    InstantiateEnemy(sniperEnemy, spawnPosition);
            //}
        }
        SetSpawnPeriod();
        SetNumEnemyTypes();
        SetEnemyCap();
        Invoke("SpawnEnemy", spawnPeriod);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    void InstantiateEnemy(GameObject type, Vector2 spawnPosition) {
		enemies.Add(Instantiate(type, spawnPosition, Quaternion.identity));
	}

    void SetSpawnPeriod()
    {
        spawnPeriod = 5f;
        //spawnPeriod = 4f - Mathf.Min(3f, timer / 100f);
    }

    void SetNumEnemyTypes()
    {
        numEnemyTypes = Mathf.Min(5, Mathf.RoundToInt(timer / 20f));
    }

    void SetEnemyCap()
    {
        enemyCap = 5 + Mathf.Min(30, Mathf.RoundToInt(timer / 30)); 
    }
        
}
