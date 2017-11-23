using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void changeScene(string level)
    {
        if (level == "quit")
            Application.Quit();
        else
            SceneManager.LoadScene(level);
    }
}
