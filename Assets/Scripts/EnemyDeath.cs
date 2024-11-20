using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FriendlyBullet")
        {
            Debug.Log("Enemy Defeated");
            EnemyManager.OnEnemyDestroyed();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(other.gameObject);
        }
    }
}

