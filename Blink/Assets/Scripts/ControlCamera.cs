using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour {
    public GameObject character;
    //private Vector3 offset = new Vector3(0,0,-5);
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
        //Makes camera track, but has weird side effects
        //transform.position = character.transform.position + offset;
	}
}
