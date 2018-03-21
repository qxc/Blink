// A persistent singleton that tracks the player's settings
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

	public static SettingsManager instance;
	public Dictionary<string, string> playerSettings;

	// Use this for initialization
	void Start () {
		playerSettings = new Dictionary<string, string>();
		playerSettings.Add("up", "w");
		playerSettings.Add("down", "s");
		playerSettings.Add("left", "a");
		playerSettings.Add("right", "d");
		playerSettings.Add("melee", "q");
		playerSettings.Add("pause", "space");
		playerSettings.Add("menu", "escape");
		playerSettings.Add("attackClosest", "j");
		playerSettings.Add("blinkKey", "k");
		List<string> keys = new List<string>(playerSettings.Keys);
		foreach (string key in keys){
			Debug.Log(PlayerPrefs.GetString(key));
			playerSettings[key] = PlayerPrefs.GetString(key);
		}

		if (instance == null ) {
			instance = this;
		}
		else {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}


	// Update is called once per frame
	void Update () {

		
	}
}
