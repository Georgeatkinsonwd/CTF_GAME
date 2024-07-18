using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isPlayerAlive = true;
    public bool hasFlag = false;
    public GameObject playerFlag;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    public GameObject playerFlagHolder;
    
    

    private int increaseDifficulty = 2;
    private Animator animator;

   
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag")) 
        {
          
            spawnManager.flag.transform.parent = playerFlagHolder.transform;
            spawnManager.flag.transform.localPosition = Vector3.zero;
            hasFlag = true;

        }


        if (other.CompareTag("Goal") && hasFlag)
        {
            
            gameManager.UpdateScore();


            spawnManager.flag.transform.parent = null;
            spawnManager.flag.transform.localPosition = spawnManager.GenerateSpawnPosition(); ;
            increaseDifficulty++;
            spawnManager.SpawnEnemies(increaseDifficulty);

            hasFlag = false;

        }

        if (other.CompareTag("Enemy"))
        {
            
            animator.SetBool("isDying", true);
            isPlayerAlive = false;
            
            gameManager.GameOver();
            hasFlag = false;
        }
    }
}
