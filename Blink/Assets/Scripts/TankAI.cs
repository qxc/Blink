using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : AI {

	// Use this for initialization
	void Start () {
        InitialStats();
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
	}
    void Update()
    {
        moveTowardPlayer();
        AttackCharacter();
    }
    void InitialStats()
    {
        attackCooldown = 2.75f;
        life = 6;
        moveSpeed = 1.5f;
        size = 2f;
        attackRange = 3.5f;
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
