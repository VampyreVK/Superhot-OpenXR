using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyBumpAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private GameObject playerTarget;

    private void OnTriggerEnter(Collider other)
    {
        //Make sure to set the layer such that other objects do not trigger the enemy
        playerTarget = other.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // Only move forward if there is a player target
        if (playerTarget is not null) {
            transform.LookAt(playerTarget.transform);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}