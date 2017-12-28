using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : BasicAI {

    // Use this for initialization
    void Start()
    {
        Init();
    }

    protected void Init()
    {
        InitialStats();
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
    }
    /*
    void Update()
    {
        MoveTowardPlayer();
        AttackCharacter();
    }
    */
    void InitialStats()
    {
        scoreChange = 4;
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
