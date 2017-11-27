using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDIcon : MonoBehaviour
{
    float duration;
    Color colorStart = Color.black;
    Color colorEnd = Color.white;
    float currentColor = 0f;
    float colorStep;
    float repeatPeriod = .05f;
    Image img;
    Character character;
    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        character = GameObject.Find("Character").GetComponent<Character>();


    }

    public void Activate(float cooldown)
    {
        duration = cooldown;
        colorStep = repeatPeriod / duration;
        img.color = colorStart;
        InvokeRepeating("ChangeColor", 0f, repeatPeriod);
    }

    public void ChangeColor()
    {
        currentColor += colorStep;
        img.color = Color.Lerp(colorStart, colorEnd, currentColor);
        if (currentColor >= 1)
        {
            CancelInvoke();
            currentColor = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
