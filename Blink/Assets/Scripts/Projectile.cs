using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    int speed = 3;
    GameObject target;

	void Start () {
		
	}
	
    public void setTarget(GameObject target_)
    {
        target = target_;
    }

	// Update is called once per frame
	void Update () {
        if(target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}
}
