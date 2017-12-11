using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour {
    GameObject character;
    float size;
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
        updateSize();
    }
	
    void updateSize()
    {
        //it's off by 2, so we add that at the end
        //print(size);
        size = (2 * character.GetComponent<Character>().getAttackRange());
        transform.localScale += new Vector3(size, size, 0);
    }

	// Update is called once per frame
	void Update () {
        //Unnecessary as these are now children of Character
        //transform.position = character.transform.position;
	}
}
