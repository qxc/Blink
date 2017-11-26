using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour {
    GameObject character;
    int size;
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");

        //it's off by 2, so we add that at the end
        size = (2 * character.GetComponent<Character>().getAttackRange())+2;
        //print(size);
        this.transform.localScale += new Vector3(size, size, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = character.transform.position;
	}
}
