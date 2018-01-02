using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAI : BasicAI {

	// Use this for initialization

    public override void InitialStats()
    {
        attackCooldown = 4f;
        life = 1;
        moveSpeed = 1f;
        size = 1.1f;
        attackRange = 4f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
    }

    // Update is called once per frame
}
