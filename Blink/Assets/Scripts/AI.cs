using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Character {

    protected GameObject character;
    protected float attackDelay = 1f;
    protected float size;
    protected int scoreChange = 1;
    protected float chargeDelay = .75f;
    public bool meleeDamaged = false;
    
    
	// Use this for initialization
	void Start () {
        InitialStats();
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        //InvokeRepeating("attackCharacter", attackDelay, attackCooldown);
        //InvokeRepeating("DebugTrackingProjectile", 0, 1f);

    }
    //Each AI gets a random set of stats when it's created
    void InitialStats()
    {
        attackCooldown = 2.75f;
        life = 2;
        moveSpeed = 3f;
        size = 1.1f;
        attackRange = 5f;
        attackTimeStamp = Time.time + attackDelay;
        SetSize();
    }

    protected void SetSize()
    {
        transform.localScale = new Vector3(size, size);
    }

    protected void RandomStats()
    {
        //life = 10;
        //Debug.Log(life);
        life = Random.Range(life-1, life+1);
        //Debug.Log(life);
        attackCooldown = Random.Range(attackCooldown-.5f, attackCooldown+.5f);
        moveSpeed = Random.Range(moveSpeed-.25f, moveSpeed+.25f);
        attackRange = Random.Range(attackRange-2, attackRange+2);
        float randSize = Random.Range(size-.25f, size+.25f);
        gameObject.transform.localScale = new Vector3(randSize, randSize);
        attackTimeStamp = Time.time + attackCooldown;
    }

    // Update is called once per frame
    void Update () {
        moveTowardPlayer();
        AttackCharacter();
	}

    protected void Attack()
    {
        CreateProjectile(character);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    protected void AttackCharacter()
    {
        if (attackTimeStamp <= Time.time)
        {
            if (Vector3.Distance(transform.position, character.transform.position) < attackRange)
            {
                attackTimeStamp = Time.time + attackCooldown;
                ChargeAttack();
                Invoke("Attack", chargeDelay);
            }
        }
    }

    protected void ChargeAttack()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
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
        //Debug.Log("Thing died");
        GameObject.Find("HUDManager").GetComponent<HUDManager>().changeScore(scoreChange);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    public void damage(int amount)
    {
        //Debug.Log(life);
        life = life - amount;
        if (life <= 0)
        {
            OnDeath();
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
