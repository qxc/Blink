using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour {

    protected int speed = 3;
    protected List<Projectile> tracking = new List<Projectile>();
    public Projectile attack;
    bool paused = false;
    protected int life = 1;
    public GameObject HUDManager;

    // Use this for initialization
    void Start () {
        FlipPause();
	}
	//figure this shit out, too tired right now. 
    public void FlipPause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void CreateProjectile(GameObject attacked)
    {
        //Converts mouse position to world units for movement purposes, not sure why z needs to be 10
        //Vector3 mousePos = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        //print(mousePos);
        Vector3 position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0);
        //print(position);
        Projectile temp = Instantiate(attack, position, Quaternion.identity);
        temp.setTarget(attacked); // Makes the projectiles track the object that spawned them
        attacked.GetComponent<Character>().tracking.Add(temp);
    }

    /*public void OnPointerClick(PointerEventData pointerEventData) // Another potential solution to detect on-click, but couldn't get it to work
    {
        Debug.Log(name + " Game Object Clicked!");
    }
    */
    // Update is called once per frame

    
    public void DestroyTrackingProjectiles()
    {
        foreach(Projectile proj in tracking)
        {
            proj.setTarget(null);
            //print("destroyed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AI")
        {
            Destroy(collision.gameObject);
            life--;
            if(life <= 0)
                restartGame();
        }
        

    }

    private void restartGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().changeScene("Game");
    }
    void setClamps()
    {
        //Binds character's movement to remain within these bounds
        float xSize = 4.4f;
        float ySize = 8.2f;
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(transform.position.y, -xSize, xSize);
        clampedPosition.x = Mathf.Clamp(transform.position.x, -ySize, ySize);
        transform.position = clampedPosition;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                CreateProjectile(hit.collider.gameObject);
                //Debug.Log("I'm hitting " + hit.collider.name);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            FlipPause();
        }
        if (!paused)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //Converts mouse position to world units for movement purposes, not sure why z needs to be 10
                transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
                DestroyTrackingProjectiles();
            }
            setClamps();
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
}
