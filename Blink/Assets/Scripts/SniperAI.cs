﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : AI {

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
        //Debug.Log("making a sniper");
        life = Random.Range(1, 2);
        attackCooldown = Random.Range(.5f, 1f);
        moveSpeed = Random.Range(.25f, 1f);
        attackDelay = Random.Range(.5f, 1f);
        attackRange = Random.Range(8f, 12f);
        float randSize = Random.Range(1.25f, 1.5f);
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
