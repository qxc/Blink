using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameLogger : MonoBehaviour
{
    // Use this for initialization
    public void WriteGameLog(string score, string time)
    {
        //int pathEnder = Random.Range(0, 1000000);
        string path = Application.persistentDataPath;
        string file = path + "/Blink.csv";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(file, true);
        Directory.CreateDirectory(path);
        //System.IO.File.WriteAllText(path2+"Blink"+ pathEnder +".txt",System.DateTime.Now + " Score: " + score + " " + "Time: " + time);
        writer.WriteLine(System.DateTime.Now + "," + score + "," + time);
        writer.Close();

        //Print the text from the file
    }
    private void Start()
    {
        //Debug.Log(Application.persistentDataPath);
    }

}
