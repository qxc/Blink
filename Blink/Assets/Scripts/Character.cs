using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    int speed = 3;
    List<Projectile> tracking;
    public Projectile attack;
	// Use this for initialization
	void Start () {
		
	}
	
    void FindTarget()
    {
        //Not detecting click on any objects. **FIX ME**
        print("casting ray");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
        }

    }

	// Update is called once per frame
	void Update () {
        //print(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            //Converts mouse position to world units for movement purposes, not sure why z needs to be 10
            transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Converts mouse position to world units for movement purposes, not sure why z needs to be 10
            Vector3 mousePos = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
            Projectile temp = Instantiate(attack, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0), Quaternion.identity);
            FindTarget();
            //temp.setTarget(gameObject); // Makes the projectiles track the object that spawned them
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {   
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {   
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {   
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
