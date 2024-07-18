using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent agent;
   
   
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

   
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
