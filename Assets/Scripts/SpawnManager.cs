using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject flag;
    public GameObject flagPrefab;
    public GameObject chickPrefab;
    public PlayerScript playerScript;
    public GameObject player;
    public float minDistanceFromPlayer = 10f;
    


    private float spawnRangeX = 40;
    private float spawnZRange = 40;
    




   public Vector3 GenerateSpawnPosition()
    {
        Vector3 position = player.transform.position;
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZRange, spawnZRange);
        Vector3 calculatedPosition = new Vector3(xPos, 0, zPos);
        if (Vector3.Distance(position,calculatedPosition) < minDistanceFromPlayer )
        {
            return GenerateSpawnPosition();
        }
         return calculatedPosition; 
        
    }

    public void SpawnEnemies(int increaseDifficulty)
    {
        for(int i = 0; i < increaseDifficulty; i++)
        {

            GameObject enemies = ObjectPool.instance.GetEnemyPooledObjects();

            if (enemies != null)
            {
                enemies.transform.position = GenerateSpawnPosition();
                enemies.SetActive(true);
            }
            
           
        }
    }

    public void SpawnFlag()
    {
     flag =  Instantiate(flagPrefab, GenerateSpawnPosition(), flagPrefab.transform.rotation);
      
    }
}
