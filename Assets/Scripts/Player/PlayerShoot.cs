using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public float speed = 25f;
    public PlayerScript playerScript;
    public float bombCooldown = 0.7f;

    private float remainingBombCooldown;
   
    void Update()
    {
        if (!playerScript.isPlayerAlive)
        {
            return;
        }

        ShootObject();

    }

    private void ShootObject()
    {
        remainingBombCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && remainingBombCooldown < 0)
        {
      
            GameObject bomb = ObjectPool.instance.GetBombPooledObjects(); 
            if (bomb != null )
            {
                bomb.transform.position = bombSpawnPoint.position;
                bomb.SetActive(true);
            }
            bomb.GetComponent<Rigidbody>().velocity = bombSpawnPoint.forward * speed;

            remainingBombCooldown = bombCooldown;
        }
    }
}
