using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Text score;
    int currentScore;
    public Text timeUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeUI.text = "Time: " + Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }

    void GameEnd()
    {
        Time.timeScale = 0.0f;
        //Fade background
        //Defeat Text on textured shield or something
        //Move Score and Time toward the center
        //Restart, main menu, quit buttons
        //Disable all controls besides clicking (destroy character? Set character inactive?)
    }   

    public void changeScore(int change)
    {
        //Debug.Log("Score changed by " + change);
        currentScore = currentScore + change;
        score.text = "Score: " + currentScore;
    }

    public void LogGame()
    {
        GameObject.Find("GameLogger").GetComponent<GameLogger>().WriteGameLog(score.text, timeUI.text);
    }
}
