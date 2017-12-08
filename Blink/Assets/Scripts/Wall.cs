using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    int life = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hit AI");
        if (collision.tag == "PlayerProjectile" || collision.tag == "AIProjectile")
        {
            Destroy(collision.gameObject);
            //print("wall hit");
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
