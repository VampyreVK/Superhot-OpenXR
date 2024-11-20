using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private static int enemyCount = 0;

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public static void OnEnemyDestroyed()
    {
        enemyCount--;
        Debug.Log("Enemy Count: " + enemyCount);

        if (enemyCount <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}