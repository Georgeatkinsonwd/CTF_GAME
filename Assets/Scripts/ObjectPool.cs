using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public SpawnManager spawnManager;

    private List<GameObject> bombPooledObjects = new List<GameObject>();
    private List <GameObject> enemyPooledObjects = new List<GameObject>();
    private int bombsToPool = 5;
    private int enemiesToPool = 20;

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;    
        }    
    }
  

    public GameObject GetBombPooledObjects()
    {
        for (int i = 0; i < bombPooledObjects.Count; i++)
        {
            if (!bombPooledObjects[i].activeInHierarchy)
            {
                return bombPooledObjects[i];
            }
        }

        return null;
    }


    public GameObject GetEnemyPooledObjects()
    {
        for (int i = 0; i < enemyPooledObjects.Count; i++)
        {
            if (!enemyPooledObjects[i].activeInHierarchy)
            {
                return enemyPooledObjects[i];
            }
        }
        return null;
    }

    public void CreatePoolObjects()
    {
        for (int i = 0; i < bombsToPool; i++)
        {
            GameObject obj = Instantiate(bombPrefab);
            obj.SetActive(false);
            bombPooledObjects.Add(obj);
        }


        for (int i = 0; i < enemiesToPool; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPooledObjects.Add(obj);
        }
    }
    
}
