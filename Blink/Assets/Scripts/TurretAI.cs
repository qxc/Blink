using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : BasicAI
{

    public override void InitialStats()
    {
        attackCooldown = 1.5f;
        life = 3;
        moveSpeed = 0f;
        size = 2f;
        attackRange = 9f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
    }
}
