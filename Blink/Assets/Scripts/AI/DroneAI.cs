using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : BasicAI
{

    public override void InitialStats()
    {
        attackCooldown = 7f;
        life = 1;
        moveSpeed = 1.2f;
        size = .8f;
        attackRange = 2f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
        minDistance = .75f;
        projectileSpeed = 3f;
    }
}
