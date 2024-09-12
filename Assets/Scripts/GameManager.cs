using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;
    private AudioSource backgroundMusic;
    public GameObject muteButton;
    public GameObject unmuteButton;
    public GameObject restartButton;

    private int points = 0;
    private int highScore;
    private float timer;
    private int timeFromSpeedUp = 10;

    void Start()
    {
        Time.timeScale = 1;
        //gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            points++;
            pointsText.text = "Points: " + points;
            timer = 0;
            timeFromSpeedUp -= 1;
        }

        if (timeFromSpeedUp == 0) {
            FindObjectOfType<PipeSpawner>().pipeSpeed += 0.5f;
            timeFromSpeedUp = 10;
        }

        
    }


        public void GameOver()
    {
        Time.timeScale = 0;
        restartButton.SetActive(true);

        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
            highScoreText.text = "High Score: " + points;
        }
    }




        public void ToggleMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
        }
        else
        {
            backgroundMusic.Play();
            muteButton.SetActive(true);
            unmuteButton.SetActive(false);
        }
    }

    public void RestartGame() {
        FindObjectOfType<PlayerController>().transform.position = new Vector3(0,0,0);
        FindObjectOfType<PlayerController>().isGameOver = false;
        

        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe")) {
            Destroy(pipe);
        }

        restartButton.SetActive(false);
        points = 0;
        pointsText.text = "Points: " + points;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        FindObjectOfType<PipeSpawner>().pipeSpeed = 2f;
        Time.timeScale= 1;
        FindObjectOfType<PipeSpawner>().timer = 0f;
        FindObjectOfType<PipeSpawner>().SpawnPipe();

    }

    
}
