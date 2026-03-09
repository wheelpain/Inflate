using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LOSE : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject YouDead;

    public Transform spawnPoint;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        playerPosition.position = spawnPoint.position;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.y <= -5f)
        {
            //YouDead.SetActive(true);
            playerHealth.TakeDamage(20);
            Respawn();
        }
        if (playerHealth.currentHealth <= 0)
        {
            YouDied();
        }
    }

        
    public void YouDied()
    {
        YouDead.SetActive(true);
    }

    // Quits the game. In the Editor this stops play mode; in a build it exits the application.
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
