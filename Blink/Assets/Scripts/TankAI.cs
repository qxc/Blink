using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : AI {

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        InvokeRepeating("attackCharacter", attackDelay, attackCooldown);
        SetStats();
	}
    void Update()
    {
        moveTowardPlayer();
        AttackCharacter();
    }
    void SetStats()
    {
        //Debug.Log("making a tank");
        life = Random.Range(4, 6);
        attackCooldown = Random.Range(.1f, .4f);
        moveSpeed = Random.Range(1f, 2f);
        attackDelay = Random.Range(.4f, .8f);
        attackRange = Random.Range(3f, 4f);
        float randSize = Random.Range(1.75f, 2.5f);
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
