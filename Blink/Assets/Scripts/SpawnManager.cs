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
    private float spawnPeriod = 4f;
    private float spawnDelay = 2f;
    int numEnemyTypes = 4;

    int timeForIncreasedPace = 60;
    bool increasedPace = false;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnPeriod);
        character = GameObject.Find("Character"); //Sets the character used for spawn tracking
    }

    public void SpawnEnemy()
    {
        /*
        float scaleFactor = ((Time.timeSinceLevelLoad / 60) / 2);
        Debug.Log("Scale Factor is" + scaleFactor);
        int intScaleFactor = Mathf.RoundToInt(scaleFactor);
        Debug.Log("Rounded Scale Factor is" + intScaleFactor);
        */
        //Debug.Log(Time.timeSinceLevelLoad);
        if(Time.timeSinceLevelLoad >= timeForIncreasedPace && !increasedPace)
        {
            CancelInvoke();
            InvokeRepeating("SpawnEnemy", spawnDelay, spawnPeriod/2);
            increasedPace = true;
        }
        int enemyType = Random.Range(0, numEnemyTypes);
        int circleSize = 4;
        int bufferDistance = 2;
        //Chooses a random location within a certain distance of the player and spawns there
        Vector2 spawnPosition = new Vector2(character.transform.position.x, character.transform.position.y)
            + (circleSize * Random.insideUnitCircle) + new Vector2(bufferDistance, bufferDistance);
        if (enemyType == 0)
        {
            enemies.Add(Instantiate(basicEnemy, spawnPosition, Quaternion.identity));
        }
        if (enemyType == 1)
        {
            enemies.Add(Instantiate(lingEnemy, spawnPosition, Quaternion.identity));
            enemies.Add(Instantiate(lingEnemy, spawnPosition, Quaternion.identity));
        }
        if (enemyType == 2)
        {
            enemies.Add(Instantiate(tankEnemy, spawnPosition, Quaternion.identity));
        }
        if (enemyType == 3)
        {
            enemies.Add(Instantiate(sniperEnemy, spawnPosition, Quaternion.identity));
        }
        /*foreach (GameObject enemy in enemies) {
            Debug.Log(enemy.ToString());
        }
        */
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
