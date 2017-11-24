using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    float speed = 6f;
    GameObject target;
    Vector3 targetPosition;

	void Start () {
		
	}
	
    public void setTarget(GameObject target_)
    {
        target = target_;
        if (target_ != null)
            targetPosition = target_.transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if (targetPosition == transform.position)
                Destroy(gameObject);
            else
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        
    }
}
