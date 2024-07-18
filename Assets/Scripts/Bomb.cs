using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float life = 1.5f;
    private float timer = 1.5f;
    

    private void Update()
    {
        life -= Time.deltaTime;
        if(life < 0)
        {
            gameObject.SetActive(false);
            life = timer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }


}
