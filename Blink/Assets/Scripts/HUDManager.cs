using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Text score;
    int currentScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScore(int change)
    {
        currentScore = currentScore + change;
        score.text = "Score: " + currentScore;
    }
}
