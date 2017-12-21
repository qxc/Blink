using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
    public GameObject wall;
    float arenaRadius;
    int numStartingWalls = 2;
    int maxWalls = 7;
    public List<GameObject> walls = new List<GameObject>();

    // Use this for initialization
    void Start () {
        arenaRadius = GameObject.Find("Background").GetComponent<SetBackground>().getArenaRadius();
        for (int i = 0; i < numStartingWalls; i++)
        {
            BuildWall();
        }
        InvokeRepeating("BuildWall", 5f, 10f);
    }
	
    private void BuildWall()
    {
        //Debug.Log(walls.Count);
        if (walls.Count < maxWalls)
        {
            float constant = 3f;
            float xCoord = Random.Range(-arenaRadius + constant, arenaRadius - constant);
            float yCoord = Random.Range(-arenaRadius + constant, arenaRadius - constant);
            walls.Add(Instantiate(wall, new Vector3(xCoord, yCoord, 0), Quaternion.identity));
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
