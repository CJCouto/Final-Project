using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int currentWave;

    public int mode;
    private bool chooseMode;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text createdText;
    public Text modeText;
    public Text modesText;
    public Text timeText;
    public Text timerText;
    private int score;
    private bool gameOver;
    private bool restart;
    public bool win;
    private int timeLeft;
    private bool soundPlaying;

    public AudioClip winClip;
    public AudioClip loseClip;
    AudioSource sound;

    void Start () {
        chooseMode = true;
        mode = 0;
        currentWave = 1;
        gameOver = false;
        restart = false;
        win = false;
        soundPlaying = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        createdText.text = "";
        timeText.text = "";
        timerText.text = "";
        score = 0;
        timeLeft = 35;
        UpdateScore();
        //StartCoroutine(SpawnWaves());
        sound = GetComponent<AudioSource>();
    }

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.T)) {
                SceneManager.LoadScene("Main");
            }
        }
        if (chooseMode) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                modeText.text = " ";
                modesText.text = " ";
                mode = 0;
                chooseMode = false;
                timeText.text = " ";
                timerText.text = " ";
                StartCoroutine(SpawnWaves());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                modeText.text = " ";
                modesText.text = " ";
                mode = 1;
                chooseMode = false;
                timeText.text = " ";
                timerText.text = " ";
                StartCoroutine(SpawnWaves());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                modeText.text = " ";
                modesText.text = " ";
                mode = 2;
                timeText.text = "Time";
                timerText.text = timeLeft.ToString();
                chooseMode = false;
                StartCoroutine(SpawnWaves());
                StartCoroutine(CountDown());
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            currentWave += 1;

            if (gameOver) {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }

            if (win) {
                createdText.text = "Created By: Christopher Couto";
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
        }
    }

    IEnumerator CountDown() {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft -= 1;
            timerText.text = timeLeft.ToString();

            if (timeLeft <= 0)
            {
                winText.text = "Time's Up!!";
                timeLeft = 0;
                win = true;
                if (soundPlaying == false)
                {
                   sound.clip = winClip;
                   sound.Play();
                   soundPlaying = true;
                }
              break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
        if (mode < 2)
        {
            if (score >= 100)
            {
                winText.text = "You Win!";
                win = true;
                if (soundPlaying == false)
                {
                    sound.clip = winClip;
                    sound.Play();
                    soundPlaying = true;
                }
            }
        }
    }

    void UpdateScore() {
        if (win == false)
        {
            ScoreText.text = "Points: " + score;
        }
    }

    public void GameOver()
    {

            if (win == false)
            {
                gameOverText.text = "Game Over";
                gameOver = true;
                if (soundPlaying == false)
                {
                    sound.loop = false;
                    sound.clip = loseClip;
                    sound.Play();
                    soundPlaying = true;
                }
            }
    }
}
