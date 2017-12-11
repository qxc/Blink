using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRadius : MonoBehaviour
{
    GameObject character;
    float size;
    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");

        //it's off by 2, so we add that at the end
        //size = (2 * character.GetComponent<Character>().getMeleeRange());
        //print(size);
        transform.localScale += new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position;
    }
}
