using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int score;
    private int life;
    private float spawnTime = 2f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;

    //Pause screen
    public GameObject pauseScreen;
    private bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GamePaused();
        }
    }

    IEnumerator SpawnObject()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife(int lifeToDecrease)
    {
        life += lifeToDecrease;
        lifeText.text = "Lives: " + life;
        if ( life <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnTime /= difficulty;
        isGameActive = true;
        titleScreen.SetActive(false);
        StartCoroutine(SpawnObject());
        score = 0;
        UpdateScore(0);
        UpdateLife(3);
    }

    void GamePaused()
    {
        if(!isPaused)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
