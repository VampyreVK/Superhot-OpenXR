using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float stopDistance = 2f;
    [SerializeField]
    private float shootPower = 100000f;
    [SerializeField]
    private float shootDistance = 2.5f;
    [SerializeField]
    private float AttackInterval = 2f;
    [SerializeField]
    private GameObject EnemyBulletTemplate;

    [SerializeField]
    private float RotationSpeed = 100f;
    
    private float TimeSinceLastAttack = 2f;

    

    private GameObject playerTarget;

    // Update is called once per frame
    void Update()
    {
        //Only move forward when we have a player target within the detection range (Enemy Sphere Collider)
        if (playerTarget != null)
        {
            //Get distance to player
            var playerDistance = Vector3.Distance(transform.position, playerTarget.transform.position);
            
            //Look at the player
            transform.LookAt(playerTarget.transform);
            
            //Move towards the player
            if (playerDistance > stopDistance)
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            
            //Make sure the enemy does not get too close to the player
            else if (playerDistance < stopDistance)
            {
                transform.position -= transform.forward * Time.deltaTime * moveSpeed;
                
                //Move enemy around player going left
                transform.RotateAround(playerTarget.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
            }
            
            //Shoot at the player
            if (playerDistance < shootDistance)
            {
                if ((TimeSinceLastAttack += Time.deltaTime) >= AttackInterval)
                {
                    ShootPlayer();
                    TimeSinceLastAttack = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Make sure to set the layer such that other objects do not trigger the enemy
        playerTarget = other.gameObject;
    }
    
    private void ShootPlayer()
    {
        // Fire Bullet
        GameObject newBullet = Instantiate(EnemyBulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }
}
