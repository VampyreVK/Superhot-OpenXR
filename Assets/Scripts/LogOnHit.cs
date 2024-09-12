using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnHit : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.name +" Collision Detected with " + other.gameObject.name);
    }
}
