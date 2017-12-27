using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject basicEnemy;
    public GameObject character;
    public GameObject lingEnemy;
    public GameObject tankEnemy;
    public GameObject sniperEnemy;
    public List<GameObject> enemies;
    
    float bufferDistance = 4f;

    public float timer = 0f;
    public float spawnPeriod = 4f;
    private float spawnDelay = 2f;
    public int enemyCap = 4;
    public int numEnemyTypes = 0;

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
        if (enemies.Count < enemyCap) {
            //Debug.Log("Below cap");
            int enemyType = Random.Range(0, numEnemyTypes);
            //Chooses a random location within a certain distance of the player and spawns there
            //Debug.Log(randomSpawn);
            
            float numEnemySpawn = Mathf.Min(3f, timer / 13f);
            for (int i = 0; i < numEnemySpawn; i++)
            {
                Vector2 spawnPosition = RandomPositionNearCharacter();
                if (enemyType == 0)
                {
                    InstantiateEnemy(basicEnemy, spawnPosition);
                }

                if (enemyType == 1)
                {
                    InstantiateEnemy(lingEnemy, spawnPosition);
                    InstantiateEnemy(lingEnemy, spawnPosition);
                }
                if (enemyType == 2)
                    InstantiateEnemy(tankEnemy, spawnPosition);
                if (enemyType == 3)
                    InstantiateEnemy(sniperEnemy, spawnPosition);
            }
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
        spawnPeriod = 4f - Mathf.Min(3f, timer / 100f);
    }

    void SetNumEnemyTypes()
    {
        numEnemyTypes = Mathf.Min(4, Mathf.RoundToInt(timer / 30f));
    }

    void SetEnemyCap()
    {
        enemyCap = Mathf.Min(30, Mathf.RoundToInt(timer / 5)); 
    }
        
}
