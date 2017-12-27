using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : AI {

	// Use this for initialization
	void Start () {
        InitialStats();
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
	}
    void Update()
    {
        MoveTowardPlayer();
        AttackCharacter();
    }
    void InitialStats()
    {
        attackCooldown = 1.9f;
        life = 1;
        moveSpeed = 2f;
        size = 1.25f;
        attackRange = 10f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
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
