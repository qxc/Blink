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
    
    float bufferDistance = 4f;

    public float timer = 0f;
    float spawnPeriod = 4f;
    private float spawnDelay = 2f;
    int enemyCap = 4;
    int numEnemyTypes = 0;

	// Use this for initialization
	void Start ()
    {
        Invoke("SpawnEnemy", spawnDelay);
        character = GameObject.Find("Character"); //Sets the character used for spawn tracking
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
        numEnemyTypes = Mathf.Min(5, Mathf.RoundToInt(timer / 15f));
    }

    void SetEnemyCap()
    {
        enemyCap = 4 + Mathf.Min(30, Mathf.RoundToInt(timer / 15)); 
    }
        
}
