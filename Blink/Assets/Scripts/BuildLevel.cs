using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour {
    public GameObject wall;
    float arenaRadius;
    // Use this for initialization
    void Start () {
        arenaRadius = GameObject.Find("Background").GetComponent<SetBackground>().getArenaRadius();
        BuildWall();
        BuildWall();
        BuildWall();
        BuildWall();
        BuildWall();
        InvokeRepeating("BuildWall", 5f, 10f);
    }
	
    private void BuildWall()
    {
        float constant = 3f;
        float xCoord = Random.Range(-arenaRadius + constant, arenaRadius - constant);
        float yCoord = Random.Range(-arenaRadius + constant, arenaRadius - constant);
        Instantiate(wall, new Vector3(xCoord, yCoord, 0), Quaternion.identity);
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
