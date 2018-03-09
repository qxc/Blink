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
		playerSettings.Add("quit", "escape");
		playerSettings.Add("attackClosest", "j");
		playerSettings.Add("blinkKey", "k");

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
