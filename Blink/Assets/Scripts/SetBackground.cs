using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackground : MonoBehaviour
{
    private float arenaRadius = 10f;
    private void Start()
    {
        gameObject.transform.localScale = new Vector3(arenaRadius, arenaRadius);
    }   

    public float getArenaRadius()
    {
        return arenaRadius;
    }
}
