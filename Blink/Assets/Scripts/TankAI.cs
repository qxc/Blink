using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : BasicAI {

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
        scoreChange = 4;
        minDistance = 1f;
        attackCooldown = 2.75f;
        life = 4;
        moveSpeed = .75f;
        size = 2f;
        attackRange = 3.5f;
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
