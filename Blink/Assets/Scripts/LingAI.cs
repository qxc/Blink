using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingAI : AI {

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        InvokeRepeating("attackCharacter", attackDelay, attackPeriod);
        SetStats();
	}
    void Update()
    {
        moveTowardPlayer();
    }
    void SetStats()
    {
        //Debug.Log("making a ling");
        life = Random.Range(1, 2);
        attackPeriod = Random.Range(.2f, .5f);
        moveSpeed = Random.Range(5f, 7f);
        attackDelay = Random.Range(1f, 2f);
        range = Random.Range(3f, 4f);
        float randSize = Random.Range(.4f, .65f);
        gameObject.transform.localScale = new Vector3(randSize, randSize);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hit AI");
        if (collision.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            //print("AI hit by player");
            life--;
            if (life <= 0)
            {
                OnDeath();
            }
        }
    }
}
