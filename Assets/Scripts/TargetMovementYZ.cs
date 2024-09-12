using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{

    public float Speed = 5f;  
    public float DistanceY = 0.5f; 
    public float DistanceZ = 0.5f; 
    private Vector3 centerPoint = new Vector3();
    private float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null)
        {
            centerPoint = gameObject.transform.position;
        }
        else
        {
            Debug.LogError("Target is not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag is not "fallenApart")
        {

            angle += Time.deltaTime * Speed;

            if (angle >= 2 * Mathf.PI)
            {
                angle -= 2 * Mathf.PI;
            }

            // Calculate new positions
            float y = centerPoint.y + Mathf.Cos(angle) * DistanceY;
            float z = centerPoint.z + Mathf.Sin(angle) * DistanceZ;

            // Update the Target's position
            gameObject.transform.position = new Vector3(centerPoint.x, y, z);
        }
    }
}