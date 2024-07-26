using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net.Sockets;



public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public Button button;
    public Button restartGame;
    public GameObject titleScreen;
    public GameObject worldView;
    public GameObject gameoverScreen;
    public SpawnManager spawnManager;
    public ObjectPool objectPool;

    private int startEnemies = 2;
    private int score = 0;



    void Start()
    {

        button.onClick.AddListener(StartGame);
    }




    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        worldView.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        objectPool.CreatePoolObjects();
        spawnManager.SpawnFlag();
        spawnManager.SpawnEnemies(startEnemies);
        
        

    }

    public void GameOver()
    {
        gameoverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
