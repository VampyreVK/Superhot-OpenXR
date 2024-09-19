using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTeleport : MonoBehaviour
{
    [SerializeField]
    private LayerMask castLayer;
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private InputActionReference teleportAction;

    
    void shoot(InputAction.CallbackContext context)
    {
        teleportAction.action.performed += DoRaycast;
    }
    
    void DoRaycast(InputAction.CallbackContext context) {
        // The Unity raycast hit object, which will store the output of our raycast
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        // Parameters: position to start the ray, direction to project the ray, output for raycast, limit of ray length, and layer mask
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, castLayer)) {
            // The object we hit will be in the collider property of our hit object.
            // We can get the name of that object by accessing its Game Object then the name property
            Debug.Log(hit.collider.gameObject.name);
        
            // Don't forget to attach the player origin in the editor!
            // Moves to center of object hit
            //playerOrigin.transform.position = hit.collider.gameObject.transform.position;
            
            //moves to the point where the raycast hit
            playerOrigin.transform.position = hit.point;
        }
    }
}
