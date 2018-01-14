using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float life = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile" || collision.tag == "AIProjectile")
        {
            Debug.Log(life);
            Destroy(collision.gameObject);
            //print("wall hit");
            life--;
            CheckLife();
        }
    }
    public void CheckLife()
    {
        if (life <= 0)
        {
            GameObject.Find("WallManager").GetComponent<WallManager>().walls.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void Damage(float amount)
    {
        life = life - amount;
        CheckLife();
    }
}
