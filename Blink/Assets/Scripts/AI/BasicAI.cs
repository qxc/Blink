using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : Character {

    protected GameObject character;
	protected GameObject explosion;
    protected float attackDelay = 1.25f;
    protected float size;
    protected int scoreChange = 1;
    protected float chargeDelay;

    protected float minDistance = 1.5f;

    public bool meleeDamaged = false;

	// Use this for initialization
	protected void Start () {
        Init(); //Sets the character used for projectile tracking
        //InvokeRepeating("attackCharacter", attackDelay, attackCooldown);
        //InvokeRepeating("DebugTrackingProjectile", 0, 1f);

    }

    protected void Init()
    {
        InitialStats();
        character = GameObject.Find("Character"); //Sets the character used for projectile tracking
        chargeDelay = Mathf.Min(.5f, attackCooldown / 2);
    }
    //Each AI gets a random set of stats when it's created
    public virtual void InitialStats()
    {
        attackCooldown = 4f;
        life = 1;
        moveSpeed = 1f;
        size = 1.1f;
        attackRange = 4f;
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
    protected void Update () {
        //Debug.Log(gameObject.name + " name and " + minDistance);
        if (CheckDistanceToPlayer() > minDistance)
        {
            MoveTowardPlayer();
        }
        else
            MoveAwayFromPlayer();
        Attack(character);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<Wall>().Damage(.01f);
        }
    }

    float CheckDistanceToPlayer()
    {
        return Vector2.Distance(gameObject.transform.position, character.transform.position);
    }

    protected void AttackCharacter()
    {
        CreateProjectile(character);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    protected void Attack(GameObject target)
    {
        if (attackTimeStamp <= Time.time)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                attackTimeStamp = Time.time + attackCooldown;
                ChargeAttack();
                if(target.tag == "PlayerCharacter")
                    Invoke("AttackCharacter", chargeDelay);
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

    protected void MoveTowardPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, character.transform.position, moveSpeed * Time.deltaTime);
    }

    protected void MoveAwayFromPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, character.transform.position, -moveSpeed * Time.deltaTime);
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
        GameObject.Find("HUDManager").GetComponent<HUDManager>().ChangeScore(scoreChange);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().RemoveEnemy(gameObject);

		Explode();
        Destroy(gameObject);
    }

	protected void Explode() {
		if ( explosion != null ) {
			GameObject kaboom = Instantiate(explosion);
			ParticleSystem.MainModule main = kaboom.GetComponent<ParticleSystem>().main;
			main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		}
	}

    public void Damage(int amount)
    {
        //Debug.Log("Damaged");
        //Debug.Log(life);
        life = life - amount;
        if (life <= 0)
        {
            OnDeath();
        }
    }

    public void AddTrackingProjectile(Projectile incomingProjectile)
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
