using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void ChangeScene(string level)
    {
        //Debug.Log(level);
        if (level == "Quit")
            Application.Quit();
        else
            SceneManager.LoadScene(level);
    }
}
