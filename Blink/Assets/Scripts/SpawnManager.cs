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
    private float spawnDelay = 2f;

    public float timer = 0f;
    public float spawnPeriod = 4f;
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

    public void SpawnEnemy()
    {
        if (enemies.Count < enemyCap) {
            int enemyType = Random.Range(0, numEnemyTypes);
            int circleSize = 4;
            int bufferDistance = 2;
            //Chooses a random location within a certain distance of the player and spawns there
            Vector2 spawnPosition = new Vector2(character.transform.position.x, character.transform.position.y)
                + (circleSize * Random.insideUnitCircle) + new Vector2(bufferDistance, bufferDistance);
            if (enemyType == 0)
                InstantiateEnemy(basicEnemy, spawnPosition);
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
        enemyCap = Mathf.Min(30, Mathf.RoundToInt(timer / 10)); 
    }
        
}
