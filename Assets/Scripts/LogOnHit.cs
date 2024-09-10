using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnHit : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Cube Collision Detected with " + other.gameObject.name);
    }
}
