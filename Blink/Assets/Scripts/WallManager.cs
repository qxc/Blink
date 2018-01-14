using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
    public GameObject wall;
    float arenaRadius;
    int numStartingWalls = 7;
    int maxWalls = 7;
    public List<GameObject> walls = new List<GameObject>();

    // Use this for initialization
    void Start () {
        arenaRadius = GameObject.Find("Background").GetComponent<SetBackground>().getArenaRadius();
        //SetupRandomWalls();
        SetupWalls();
    }
	
    void SetupWalls()
    {
        for(int i = 0; i < numStartingWalls; i++)
        {
            BuildXAdjacentHWalls(3);
            BuildXAdjacentVWalls(3);
        }
        
        
    }

    void BuildXAdjacentVWalls(int num)
    {
        float squareWidth = 1f;
        float offset = 3f;
        float xCoord = Mathf.RoundToInt(Random.Range(-arenaRadius + offset, arenaRadius - offset));
        float yCoord = Mathf.RoundToInt(Random.Range(-arenaRadius + offset, arenaRadius - offset));
        for(int i = 0; i < num; i++)
        {
            walls.Add(Instantiate(wall, new Vector3(xCoord, yCoord + squareWidth * i, 0), Quaternion.identity));
        }
       
    }

    void BuildXAdjacentHWalls(int num)
    {
        float squareWidth = 1f;
        float offset = 3f;
        float xCoord = Mathf.RoundToInt(Random.Range(-arenaRadius + offset, arenaRadius - offset));
        float yCoord = Mathf.RoundToInt(Random.Range(-arenaRadius + offset, arenaRadius - offset));
        for (int i = 0; i < num; i++)
        {
            walls.Add(Instantiate(wall, new Vector3(xCoord + squareWidth * i, yCoord, 0), Quaternion.identity));
        }

    }

    void SetupRandomWalls()
    {
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
