using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour {
    public GameObject wall;
    private int height = 5;
    private int width = 9;
    // Use this for initialization
    void Start () {
        BuildWalls();
	}
	
    private void BuildWalls()
    {
        for (int l = -width; l <= width; l = l + 2 * width)
        {
            for (int i = -height; i < height; i++)
            {
                Instantiate(wall, new Vector3(l, i, 0), Quaternion.identity);
            }
        }
        for (int k = -height; k <= height; k = k + 2*height)
        {
            for (int j = -width; j < width; j++)
            {
                Instantiate(wall, new Vector3(j, k, 0), Quaternion.identity);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
