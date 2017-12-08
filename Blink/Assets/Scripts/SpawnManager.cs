using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject basicEnemy;
    public GameObject character;
    public GameObject lingEnemy;
    public GameObject tankEnemy;
    public GameObject sniperEnemy;
    private float spawnPeriod = 5f;
    private float spawnDelay = 5f;
    int numEnemyTypes = 4;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnPeriod);
        character = GameObject.Find("Character"); //Sets the character used for spawn tracking
    }

    public void SpawnEnemy()
    {
        int enemyType = Random.Range(0, numEnemyTypes);
        int circleSize = 4;
        int bufferDistance = 2;
        //Chooses a random location within a certain distance of the player and spawns there
        Vector2 spawnPosition = new Vector2(character.transform.position.x, character.transform.position.y)
            + (circleSize * Random.insideUnitCircle) + new Vector2(bufferDistance, bufferDistance);
        if (enemyType == 0)
        {
            Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
        }
        if (enemyType == 1)
        {
            Instantiate(lingEnemy, spawnPosition, Quaternion.identity);
        }
        if (enemyType == 2)
        {
            Instantiate(tankEnemy, spawnPosition, Quaternion.identity);
        }
        if (enemyType == 3)
        {
            Instantiate(sniperEnemy, spawnPosition, Quaternion.identity);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
