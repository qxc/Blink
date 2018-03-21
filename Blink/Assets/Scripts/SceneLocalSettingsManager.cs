// a dumb proxy to connect the persistent settings manager to the settings UI in the settings scene.
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
		foreach (KeyValuePair<string, string> item in playerSettings){
			GameObject.Find(item.Key).GetComponent<Text>().text = PlayerPrefs.GetString(item.Key); 
		}

	}


	void OnGUI() {

		Event e = Event.current;
		if (e.isKey){
			Debug.Log("Detected key code: " + e.keyCode.ToString());
		}
		if ( e.isKey && (waitingForInputToSetThisKey != "") ) {
			Debug.Log(waitingForInputToSetThisKey);
			playerSettings[waitingForInputToSetThisKey] = e.keyCode.ToString().ToLower();
			GameObject.Find(waitingForInputToSetThisKey).GetComponent<Text>().text = e.keyCode.ToString().ToLower(); 
			waitingForInputToSetThisKey = "";
			foreach (KeyValuePair<string, string> item in playerSettings){
				Debug.Log(item.Key + " " + item.Value);
				PlayerPrefs.SetString(item.Key, item.Value);
			}
			PlayerPrefs.Save();
		}
		
	}

	// Update is called once per frame
	void Update () {

		
	}
}
