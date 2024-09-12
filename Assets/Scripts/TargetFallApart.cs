using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFallApart : MonoBehaviour
{
    public GameObject[] subPieces;  // Array of subpieces

    private bool hasFallenApart = false;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the target has collided with an object and hasn't already fallen apart
        if (!hasFallenApart)
        {
            hasFallenApart = true;
            gameObject.tag = "fallenApart";
            FallApart();
        }
    }

    void FallApart()
    {
        foreach (GameObject piece in subPieces)
        {
            // Disable kinematic so gravity takes effect and the pieces fall
            piece.GetComponent<Rigidbody>().isKinematic = false;
            piece.GetComponent<Rigidbody>().useGravity = true;
            

            // Optionally, apply an initial explosion force to make them scatter
            piece.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 5f);
        }
    }
}