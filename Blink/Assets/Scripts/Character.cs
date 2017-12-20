using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour {

    protected float moveSpeed = 3;
    protected List<Projectile> tracking = new List<Projectile>();
    public Projectile attack;
    bool paused = false;
    protected int life = 1;
    public GameObject HUDManager;

    private float blinkRange = 3;
    private float blinkCooldown = 1f;
    private float blinkTimeStamp;

    protected float attackRange = 4;
    protected float attackCooldown = 3f;
    protected float attackTimeStamp;

    //private float meleeCooldown = .5f;
    private int meleeDamage = 2;
    bool isMelee = false;
    private float meleeSpeed = .3f;

    //private int cameraZ = -1;

    private float arenaRadius;

    string pause = "space";
    string up = "w";
    string down = "s";
    string left = "a";
    string right = "d";
    string melee = "q";
    string attackClosest = "j";
    string blinkKey = "k";

	SpawnManager spawnManager;

    public GameObject marker;

    public float getBlinkRange()
    {
        return blinkRange;
    }
    public float getAttackRange()
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
        Time.timeScale = 1.0f;
        arenaRadius = GameObject.Find("Background").GetComponent<SetBackground>().getArenaRadius();
		spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
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
        if (collision.tag == "AIProjectile")
        {
            Destroy(collision.gameObject);
            //if (!isMelee)
            //{
                //Debug.Log("Hit by " + collision.name);
                life--;
                if (life <= 0)
                    RestartGame();
            //}
        }
		if (collision.gameObject.tag == "AICharacter" && isMelee)
		{
			AI ai = collision.gameObject.GetComponent<AI>();
			if (!ai.meleeDamaged) ai.damage(meleeDamage);
			ai.meleeDamaged = true;
			
		}
    }

    private void RestartGame()
    {
        Time.timeScale = 0.0f;
        GameObject.Find("HUDManager").GetComponent<HUDManager>().LogGame();
        GameObject.Find("MenuManager").GetComponent<MenuManager>().ShowDefeat();
        gameObject.SetActive(false);
        //GameObject.Find("LevelManager").GetComponent<LevelManager>().ChangeScene("Game");
    }
    void SetClamps()
    {
        //Binds character's movement to remain within these bounds
        //float xSize = 4.4f;
        //float ySize = 8.2f;
        /*
        float xSize = 12f;
        float ySize = 12f;
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(transform.position.y, -xSize, xSize);
        clampedPosition.x = Mathf.Clamp(transform.position.x, -ySize, ySize);
        transform.position = clampedPosition;
        */
        
        //clamps movement within a circle of arenaSize
        transform.position = Vector3.ClampMagnitude(transform.position, arenaRadius);
        //Debug.Log(Vector3.Distance(transform.position, new Vector3(0, 0, 0)));
    }

    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject e in enemies)
        {
            if (e != null)
            {
                float dist = Vector3.Distance(e.transform.position, currentPos);
                if (dist < minDist)
                {
                    closest = e;
                    minDist = dist;
                }
            }
        }
        return closest;
    }
    void AttackClosestEnemy(List<GameObject> enemies)
    {
        if (attackTimeStamp <= Time.time)
        {
            GameObject closestEnemy = GetClosestEnemy(enemies);
            if (closestEnemy != null)
            {
                float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);
                //Debug.Log(distance);
                if (distance <= attackRange)
                {
                    //GameObject.Find("AttackCDIcon").GetComponent<CDIcon>().Activate(attackCooldown);
                    GameObject.Find("AttackCooldownManager").GetComponent<AttackBarCooldown>().Activate(attackCooldown);
                    CreateProjectile(closestEnemy);
                    attackTimeStamp = Time.time + attackCooldown;
                    //Debug.Log("I'm hitting " + hit.collider.name);
                }
            }
                }
    }

    string FindCurrentDirection()
    {
        if (Input.GetKey(up))
        {
            if (Input.GetKey(left))
                return "UpLeft";
            else if (Input.GetKey(right))
                return "UpRight";
            else
                return "Up";
        }
        else if (Input.GetKey(down))
        {
            if (Input.GetKey(left))
                return "DownLeft";
            else if (Input.GetKey(right))
                return "DownRight";
            else
                return "Down";
        }
        else if (Input.GetKey(left))
            return "Left";
        else if (Input.GetKey(right))
            return "Right";
        return "None";
    }

    void BlinkInDirection(string direction)
    {
        if (direction == "Up")
            transform.position = transform.position + new Vector3(0, blinkRange, 0);
        if (direction == "UpRight")
            transform.position = transform.position + new Vector3(blinkRange, blinkRange, 0);
        if (direction == "UpLeft")
            transform.position = transform.position + new Vector3(-blinkRange, blinkRange, 0);
        if (direction == "Left")
            transform.position = transform.position + new Vector3(-blinkRange, 0, 0);
        if (direction == "Right")
            transform.position = transform.position + new Vector3(blinkRange, 0, 0);
        if (direction == "DownLeft")
            transform.position = transform.position + new Vector3(-blinkRange, -blinkRange, 0);
        if (direction == "Down")
            transform.position = transform.position + new Vector3(0, -blinkRange, 0);
        if (direction == "DownRight")
            transform.position = transform.position + new Vector3(blinkRange, -blinkRange, 0);
    }

    void BlinkCleanup()
    {
        //GameObject.Find("BlinkCDIcon").GetComponent<CDIcon>().Activate(blinkCooldown);
        GameObject.Find("BlinkCooldownManager").GetComponent<BarCooldown>().Activate(blinkCooldown);
        blinkTimeStamp = Time.time + blinkCooldown; // tells you when blink goes off cooldown
        DestroyTrackingProjectiles();
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
                            float distance = Vector3.Distance(gameObject.transform.position, hit.transform.position);
                            //Debug.Log(distance + " to click when attacking");
                            if (distance <= attackRange)
                            {
                                //GameObject.Find("AttackCDIcon").GetComponent<CDIcon>().Activate(attackCooldown);
                                GameObject.Find("AttackCooldownManager").GetComponent<AttackBarCooldown>().Activate(attackCooldown);
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
                    //Converts mouse position to world units for movement purposes
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                    //Can't teleport onto another object
                    //if (hit.collider == null)
                    //{
                        //Checks range, blinks to location if within range, otherwise blinks as close as possible
                        //float distance = Vector3.Distance(gameObject.transform.position, pos);
                        //Debug.Log(distance + " to click when blinking" );
                        //if (distance < blinkRange)
                        
                            //takes care of all the clean-up associated with blink without doing the actual movement
                            BlinkCleanup();
                            //Blink to targeted location even if it is out of range
                            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                            //Marker used to see where you blink and where you clicked for debugging
                            //Instantiate(marker, mousePos, Quaternion.identity);
                            Vector3 offset = mousePos - transform.position;
                            transform.position = transform.position + Vector3.ClampMagnitude(offset,blinkRange);
                            //Instantiate(marker, transform.position, Quaternion.identity);
                            //Makes blink only work if use it within range
                            //transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)));
                        
                    //}
                }
               
            }
            if (Input.GetKeyDown(blinkKey))
            {
                if (blinkTimeStamp <= Time.time)
                {
                    BlinkInDirection(FindCurrentDirection());
                    BlinkCleanup();
                }
            }
            SetClamps();
            if (!isMelee)
            {
                if (Input.GetKey(up))
                {
                    transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                }
                if (Input.GetKey(down))
                {
                    transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                }
                if (Input.GetKey(right))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
                if (Input.GetKey(left))
                {
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
                if (Input.GetKeyDown(attackClosest))
                {
                    AttackClosestEnemy(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().enemies);
                }
            }
            if (isMelee)
            {
				transform.Rotate(Vector3.forward * (360f / meleeSpeed) * Time.deltaTime);
            }
            else
            {
                if (Input.GetKeyDown(melee))
                {
                    isMelee = true;
					Invoke("MeleeEnd", meleeSpeed);
                }

            }
        }
    }

	void MeleeEnd() {
		foreach (GameObject enemy in spawnManager.enemies) {
			enemy.GetComponent<AI>().meleeDamaged = false;
		}
		transform.rotation = new Quaternion(0, 0, 0, 0);
		isMelee = false;
	}
}
