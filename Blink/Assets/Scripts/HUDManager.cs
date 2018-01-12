using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public SpawnManager spawnManager;
    public Text score;
    int currentScore;
    public Text timeUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeUI.text = "Time: " + Mathf.RoundToInt(spawnManager.timer).ToString();
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

    public void ChangeScore(int change)
    {
        //Debug.Log("Score changed by " + change);
        currentScore = currentScore + change;
        score.text = "Score: " + currentScore;
    }

    public void LogGame()
    {
        if(PlayerPrefs.GetInt("HighScore") < currentScore)
            PlayerPrefs.SetInt("HighScore", currentScore);
        string [] tempScore = score.text.Split(' ');
        string splitScore = tempScore[1];
        string[] tempTime = timeUI.text.Split(' ');
        string splitTime = tempTime[1];
        GameObject.Find("GameLogger").GetComponent<GameLogger>().WriteGameLog(splitScore, splitTime);
    }
}
