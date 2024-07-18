using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    public float speed = 10;

    [SerializeField] private CharacterController enemyController;


   
    void Update()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        Vector3 playerPos = player.transform.position;
        Vector3 newPos = new Vector3(playerPos.x, 0, playerPos.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        transform.LookAt(player.transform);


        

    }

 

}
