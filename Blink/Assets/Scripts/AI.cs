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
        randomStats();
        InvokeRepeating("attackCharacter", attackDelay, attackPeriod);
        //InvokeRepeating("DebugTrackingProjectile", 0, 1f);

    }
    //Each AI gets a random set of stats when it's created
    void randomStats()
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
                GameObject.Find("HUDManager").GetComponent<HUDManager>().changeScore(1);
                Destroy(gameObject);
            }
        }
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
