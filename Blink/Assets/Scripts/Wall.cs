using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    int life = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile" || collision.tag == "AIProjectile")
        {
            Destroy(collision.gameObject);
            //print("wall hit");
            life--;
            if (life <= 0)
            {
                GameObject.Find("WallManager").GetComponent<WallManager>().walls.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
