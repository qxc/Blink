using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text defeat;
    public Text restart;
    public Text mainmenu;
    public Text quit;
    public Image defeatBackground;

    List<Text> allText = new List<Text>();
    void Start()
    {
        allText.Add(defeat);
        allText.Add(restart);
        allText.Add(mainmenu);
        allText.Add(quit);
        defeatBackground.enabled = false;
        HideDefeat();
    }

    public void ShowDefeat()
    {
        foreach (Text text in allText)
        {
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

    }
}
