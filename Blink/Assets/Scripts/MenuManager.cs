using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public Text defeat;
    public Text restart;
    public Text mainmenu;
    public Text quit;
    public Image defeatBackground;
    public Text highscore;

    string pause;

    bool GameOver;
    List<Text> allText = new List<Text>();
    void Start()
    {
        GameOver = false;
        allText.Add(defeat);
        allText.Add(restart);
        allText.Add(mainmenu);
        allText.Add(quit);
        allText.Add(highscore);
        defeatBackground.enabled = false;
        HideDefeat();
    }

    public void ShowDefeat()
    {
        GameOver = true;
        foreach (Text text in allText)
        {
            highscore.text = "Current High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
            text.enabled = true;
        }
        defeatBackground.enabled = true;
    }

    public void HideDefeat()
    {
        foreach (Text text in allText)
        {
            //Debug.Log("Disable");
            text.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            if (Input.GetKey(Character.pause))
                GameObject.Find("LevelManager").GetComponent<LevelManager>().ChangeScene("Game");
            if (Input.GetKey(Character.quit))
                GameObject.Find("LevelManager").GetComponent<LevelManager>().ChangeScene("Quit");
        }
    }
}
