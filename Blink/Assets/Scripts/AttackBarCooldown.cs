﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBarCooldown : BarCooldown {
    
	// Use this for initialization
	void Start () {
        fill.rectTransform.localScale = new Vector3(0, 0, 0);
        bar.rectTransform.localScale = new Vector3(0, 0, 0);
        character = GameObject.Find("Character").GetComponent<Character>();
        //Uses the offset for the blink bar and puts this slightly above that one
        verticalOffset = GameObject.Find("BlinkCooldownManager").GetComponent<BarCooldown>().verticalOffset + .25f;
    }
}
