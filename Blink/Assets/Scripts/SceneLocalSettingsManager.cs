using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLocalSettingsManager : MonoBehaviour {

	public SettingsManager settingsManager;
	public Dictionary<string, string> playerSettings;
	public string waitingForInputToSetThisKey;


	public void waitForInput(string which){
		settingsManager.waitForInput(which);
	}


	// Use this for initialization
	void Start () {

		settingsManager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
		playerSettings = settingsManager.playerSettings;

	}


	void OnGUI() {
		Event e = Event.current;
		if ( e.isKey && (waitingForInputToSetThisKey != "") ) {
			Debug.Log(waitingForInputToSetThisKey);
			Debug.Log("Detected key code: " + e.keyCode.ToString());
			playerSettings[waitingForInputToSetThisKey] = e.keyCode.ToString();
			waitingForInputToSetThisKey = "";
		}
		
	}

	// Update is called once per frame
	void Update () {

		
	}
}
