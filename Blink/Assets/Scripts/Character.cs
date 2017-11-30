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

    private int blinkRange = 7;
    private float blinkCooldown = 1f;
    private float blinkTimeStamp;

    private int attackRange = 6;
    private float attackCooldown = 3f;
    private float attackTimeStamp;

    private int cameraZ = -1;

    string pause = "space";
    string up = "w";
    string down = "s";
    string left = "a";
    string right = "d";

    public int getBlinkRange()
    {
        return blinkRange;
    }
    public int getAttackRange()
    {
        return attackRange;
    }
    public float getBlinkCooldown()
    {
        return blinkCooldown;
    }
    public float getAttackCooldown()
    {
        return attackCooldown;
    }
    // Use this for initialization
    void Start () {
        FlipPause();
	}

    //Pauses if unpaused, unpauses if paused
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
        //Spawns the projectile .5 units from the character in the direction of its target
        Vector3 direction = .5f*(-gameObject.transform.position + attacked.transform.position).normalized;
        Projectile temp = Instantiate(attack, direction+gameObject.transform.position, Quaternion.identity);
        //Vector3 position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0);
        //print(position);
        temp.setTarget(attacked); // Makes the projectiles track attacked
        // Stores the projectile in the attacked unit's list so it can be updated
        attacked.GetComponent<Character>().tracking.Add(temp); 
    }

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
                RestartGame();
        }
        

    }

    private void RestartGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().changeScene("Game");
    }
    void SetClamps()
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
        
        if (Input.GetKeyDown(pause))
        {
            FlipPause();
        }
        if (!paused)
        {
            if (Input.GetMouseButtonDown(0))
                if(attackTimeStamp <= Time.time) {
                    {
                        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                        if (hit.collider != null && hit.collider.tag == "AICharacter")
                        {
                            float distance = Vector3.Distance(gameObject.transform.position, hit.transform.position) + cameraZ;
                            //Debug.Log(distance + " to click when attacking");
                            if (distance < attackRange)
                            {
                                GameObject.Find("AttackCDIcon").GetComponent<CDIcon>().Activate(attackCooldown);
                                GameObject.Find("AttackCooldownManager").GetComponent<BarCooldown>().Activate(attackCooldown);
                                CreateProjectile(hit.collider.gameObject);
                                attackTimeStamp = Time.time + attackCooldown;
                                //Debug.Log("I'm hitting " + hit.collider.name);
                            }
                        }
                    }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (blinkTimeStamp <= Time.time)
                {
                    //Converts mouse position to world units for movement purposes, not sure why z needs to be 10
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                    //Can't teleport onto another object
                    if (hit.collider == null)
                    {
                        //Checks range, blinks to location if within range, otherwise blinks as close as possible

                        float distance = Vector3.Distance(gameObject.transform.position, pos) + cameraZ;
                        //Debug.Log(distance + " to click when blinking" );
                        //if (distance < blinkRange)
                        if(true)
                        {
                            GameObject.Find("BlinkCDIcon").GetComponent<CDIcon>().Activate(blinkCooldown);
                            GameObject.Find("BlinkCooldownManager").GetComponent<BarCooldown>().Activate(blinkCooldown);
                            blinkTimeStamp = Time.time + blinkCooldown; // tells you when blink goes off cooldown
                            //Blink to targeted location even if it is out of range
                            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                            Vector3 offset = mousePos - transform.position;
                            transform.position = transform.position+ Vector3.ClampMagnitude(offset,blinkRange);
                            //Makes blink only work if use it within range
                            //transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)));
                            DestroyTrackingProjectiles();
                        }
                    }
                }
               
            }
            SetClamps();
            if (Input.GetKey(up))
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(down))
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (Input.GetKey(right))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(left))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
    }
}
