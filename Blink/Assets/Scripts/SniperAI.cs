using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : BasicAI {

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
        scoreChange = 3;
        minDistance = 5f;
        attackCooldown = 1.9f;
        life = 1;
        moveSpeed = 1f;
        size = 1.25f;
        attackRange = 10f;
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
