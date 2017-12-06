using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject character;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - character.transform.position;
    }

    void LateUpdate()
    {
        transform.position = character.transform.position + offset;
    }
}
