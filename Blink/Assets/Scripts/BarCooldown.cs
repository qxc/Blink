using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCooldown : MonoBehaviour
{

    public Image bar;
    public Image fill;

    float duration;
    float changeStep;
    float repeatPeriod = .05f;
    float verticalOffset = .75f;
    Character character;
    // Use this for initialization
    void Start()
    {
        fill.rectTransform.localScale = new Vector3(0, 0, 0);
        bar.rectTransform.localScale = new Vector3(0, 0, 0);
        character = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.rectTransform.position = Camera.main.WorldToScreenPoint(character.transform.position + new Vector3(0, verticalOffset, 0));
        fill.rectTransform.position = Camera.main.WorldToScreenPoint(character.transform.position + new Vector3(0, verticalOffset, 0));
    }

    public void Activate(float cooldown)
    {
        duration = cooldown;
        changeStep = repeatPeriod / duration;
        InvokeRepeating("ChangeSize", 0f, repeatPeriod);
        fill.rectTransform.localScale = new Vector3(0, 1, 0);
        bar.rectTransform.localScale = new Vector3(1, 1, 0);
    }

    public void ChangeSize()
    {
        //Debug.Log("changing size by " + changeStep);
        fill.rectTransform.localScale += new Vector3(changeStep, 0, 0);

        if (fill.transform.localScale.x >= 1)
        {
            CancelInvoke();
            fill.rectTransform.localScale = new Vector3(0, 0, 0);
            bar.rectTransform.localScale = new Vector3(0, 0, 0);
        }
    }
}