using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    float speed = 4f;
    GameObject target;
    Vector3 targetPosition;
    public bool hasTarget;

    public void setTarget(GameObject target_)
    {
        target = target_;
        if (target_ == null)
        {
            hasTarget = false;
        }
        else
        {
            targetPosition = target_.transform.position;
            hasTarget = true;
        }
    }

    public void SetSpeed(float speed_)
    {
        speed = speed_;
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }


    }
    */
    // Update is called once per frame
    void Update () {
        //Debug.Log("WhynoRotate");
        transform.Rotate(Vector3.back *1000 * Time.deltaTime);
        if (target == null)
        {
            hasTarget = false;
            //Debug.Log(hasTarget);
            //Turns 'dead' projectiles a different color
            gameObject.GetComponent<Renderer>().material.color = Color.black;
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
