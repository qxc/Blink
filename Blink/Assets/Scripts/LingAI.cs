using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingAI : BasicAI {
	// Use this for initialization
        /*
    void Update()
    {
        MoveTowardPlayer();
        AttackCharacter();
    }
    */
    public override void InitialStats()
    {
        minDistance = .1f;
        attackCooldown = 1.5f;
        life = 1;
        moveSpeed = 3f;
        size = .8f;
        attackRange = 3f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
    }
    /*
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
    */
}
