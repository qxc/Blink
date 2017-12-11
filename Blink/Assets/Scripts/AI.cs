using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Character {

    protected GameObject character;
    protected float attackPeriod = 1.25f;
    protected float attackDelay = 1f;
    protected float range = 5f;
    protected float size = 1f;
    
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        SetStats();
        InvokeRepeating("attackCharacter", attackDelay, attackPeriod);
        //InvokeRepeating("DebugTrackingProjectile", 0, 1f);

    }
    //Each AI gets a random set of stats when it's created
    void SetStats()
    {
        //life = 10;
        life = Random.Range(2, 4);
        attackPeriod = Random.Range(.75f, 1.25f);
        moveSpeed = Random.Range(2f, 4f);
        attackDelay = Random.Range(.25f, 2f);
        range = Random.Range(4f, 7f);
        float randSize = Random.Range(.75f, 1.25f);
        gameObject.transform.localScale = new Vector3(randSize, randSize);
    }
    //First try at how might do scaling over time. Is this a good idea? 
    //Maybe better to just introduce new enemies
    public void Initialize(int intScaleFactor, float floatScaleFactor)
    {
        life = Random.Range(2+intScaleFactor, 4+intScaleFactor);
        moveSpeed = Random.Range(2f+floatScaleFactor, 4f+floatScaleFactor);
        range = Random.Range(4f+floatScaleFactor, 7f+floatScaleFactor);

        attackPeriod = Random.Range(.75f-Mathf.Log(floatScaleFactor), 1.25f-Mathf.Log(floatScaleFactor));

        attackDelay = Random.Range(.25f, 2f);
        float randSize = Random.Range(.75f, 1.25f);
        gameObject.transform.localScale = new Vector3(randSize, randSize);
    }

    // Update is called once per frame
    void Update () {
        moveTowardPlayer();
	}

    protected void attackCharacter()
    {
        if(Vector3.Distance(transform.position,character.transform.position) < range)
            CreateProjectile(character);
    }

    protected void DebugTrackingProjectile()
    {
        foreach(Projectile proj in tracking)
        {
            print(proj);
        }
    }

    protected void moveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, character.transform.position, .5f* moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hit AI");
        if (collision.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            //print("AI hit by player");
            life--;
            if (life <= 0)
            {
                OnDeath();
            }
        }
    }

    protected void OnDeath()
    {
        GameObject.Find("HUDManager").GetComponent<HUDManager>().changeScore(1);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    public void damage(int amount)
    {
        //Debug.Log(life);
        life = life - amount;
        if (life <= 0)
        {
            GameObject.Find("HUDManager").GetComponent<HUDManager>().changeScore(1);
            Destroy(gameObject);
        }
    }

    public void addTrackingProjectile(Projectile incomingProjectile)
    {
        tracking.Add(incomingProjectile);
    }

    /* // Another way I was experimenting with to check click detection
    private void OnMouseDown()
    {
        //When you click on the ai with left click, it tells your character to create a projectile that spawns next to you and moves toward the AI
        character.GetComponent<Character>().CreateProjectile(gameObject);
    }*/
}
