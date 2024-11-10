using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyBumpAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameObject playerTarget;

    // When the player enters the trigger, assign it as a target
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Damage") {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only move forward if there is a player target
        if (playerTarget is not null) {
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
