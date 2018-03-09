using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLocalSettingsManager : MonoBehaviour {

	public SettingsManager settingsManager;
	public Dictionary<string, string> playerSettings;
	public string waitingForInputToSetThisKey;



	public void waitForInput(string whichKey){
		print("Waiting for input to set " + whichKey);
		waitingForInputToSetThisKey = whichKey;
		GameObject.Find(waitingForInputToSetThisKey).GetComponent<Text>().text = "...";
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
			playerSettings[waitingForInputToSetThisKey] = e.keyCode.ToString().ToLower();
			GameObject.Find(waitingForInputToSetThisKey).GetComponent<Text>().text = e.keyCode.ToString().ToLower(); 
			waitingForInputToSetThisKey = "";
		}
		
	}

	// Update is called once per frame
	void Update () {

		
	}
}
