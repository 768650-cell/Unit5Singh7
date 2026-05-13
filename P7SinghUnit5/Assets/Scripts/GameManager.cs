using NUnit.Framework; 
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public Button restartButton;
    private float spawnRate = 2.0f;
    private int score;
    public bool isGameActive;
    public TextMeshProUGUI livesText;
    private int lives;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);         
        }     
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToChange) 
    { 
        lives += livesToChange; 
        livesText.text = "Lives: " + lives; 
        if (lives <= 0) 
        {
            GameOver(); 
        } 
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        

        titleScreen.gameObject.SetActive(false);
    }

   
}
