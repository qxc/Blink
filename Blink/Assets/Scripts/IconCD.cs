using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCD : MonoBehaviour {

    public Image fillLayer;
    public Image icon;
    protected Character character;
    protected float verticalOffset = .8f;
    protected float horizontalOffset = .3f;
    protected float scale = .20f;

    protected float repeatPeriod = .05f;
    protected float duration;
    protected float changeStep;
    protected float currentStep;

    // Use this for initialization
    void Start () {
        Init();
        //Activate(3);
     //   SetPosition();
    }
	
    protected void Init()
    {
        Hide();
        character = GameObject.Find("Character").GetComponent<Character>();
        SetPosition();

    }

    protected void SetPosition()
    {
        fillLayer.rectTransform.position = Camera.main.WorldToScreenPoint(character.transform.position + new Vector3(horizontalOffset, verticalOffset, 0));
        icon.rectTransform.position = Camera.main.WorldToScreenPoint(character.transform.position + new Vector3(horizontalOffset, verticalOffset, 0));
    }

    protected void Hide()
    {
        fillLayer.rectTransform.localScale = new Vector3(0, 0, 0);
        icon.rectTransform.localScale = new Vector3(0, 0, 0);
    }

    protected void Show()
    {
        fillLayer.rectTransform.localScale = new Vector3(scale, scale, 0);
        icon.rectTransform.localScale = new Vector3(scale, scale, 0);
    }

    protected void Fade()
    {
        if (currentStep >= 1)
        {
            Hide();
            CancelInvoke();
        }
        else
        {
            fillLayer.color = new Color(0, 0, 0, currentStep);
            currentStep += changeStep;
        }
    }

    public void Activate(float cooldown)
    {
        duration = cooldown;
        changeStep = (repeatPeriod / duration);
        currentStep = 0f;
        Show();
        InvokeRepeating("Fade", 0f, repeatPeriod);
        
    }

    // Update is called once per frame
    void Update () {
        //SetPosition();
	}
}
