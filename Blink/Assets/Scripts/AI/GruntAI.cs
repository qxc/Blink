using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAI : BasicAI {

	// Use this for initialization

    public override void InitialStats()
    {
        attackCooldown = 3f;
        life = 1;
        moveSpeed = 1f;
        size = 1.1f;
        attackRange = 4.5f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
        scoreChange = 2;
        projectileSpeed = 4.5f;
    }

    // Update is called once per frame
}
