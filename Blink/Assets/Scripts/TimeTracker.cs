using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {
    public Text timeUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeUI.text = "Time: " + Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();

    }
}
