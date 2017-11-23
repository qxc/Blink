using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject basicEnemy;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", 1f, 5f);
    }

    public void SpawnEnemy()
    {
        Instantiate(basicEnemy, Random.insideUnitCircle, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
