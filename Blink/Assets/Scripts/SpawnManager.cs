using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject basicEnemy;
    public GameObject character;
    private float spawnPeriod = 5f;
    private float spawnDelay = 5f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnPeriod);
        character = GameObject.Find("Character"); //Sets the character used for spawn tracking
    }

    public void SpawnEnemy()
    {
        //Chooses a random location within a certain distance of the player and spawns there
        int circleSize = 4;
        int bufferDistance = 2;
        Vector2 spawnPosition = new Vector2(character.transform.position.x, character.transform.position.y)
            + (circleSize*Random.insideUnitCircle) + new Vector2(bufferDistance,bufferDistance);
        Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
