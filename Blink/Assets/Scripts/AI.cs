using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Character {

    private GameObject character;
    
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        life = 5;
        InvokeRepeating("attackCharacter", 0, 1f);
        //InvokeRepeating("DebugTrackingProjectile", 0, 1f);

    }

    // Update is called once per frame
    void Update () {
        moveTowardPlayer();
	}

    void attackCharacter()
    {
        CreateProjectile(character);
    }

    void DebugTrackingProjectile()
    {
        foreach(Projectile proj in tracking)
        {
            print(proj);
        }
    }

    private void moveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, character.transform.position, .5f* speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hit AI");
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            //print("AI hit by player");
            life--;
            if (life <= 0)
            {
                GameObject.Find("HUDManager").GetComponent<HUDManager>().changeScore(1);
                Destroy(gameObject);
            }
        }
    }

    public void addTrackingProjectile(Projectile incomingProjectile)
    {
        tracking.Add(incomingProjectile);
    }

    private void OnMouseDown()
    {
        //When you click on the ai with left click, it tells your character to create a projectile that spawns next to you and moves toward the AI
        character.GetComponent<Character>().CreateProjectile(gameObject);
    }
}
