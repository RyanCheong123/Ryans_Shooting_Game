using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Text scoreText;
    public GameObject ast;
    public static GameManager instance;
    public List<GameObject> enemies;
    float time = 0;
    public float spawnTime = 2;
    public int enemySpawnTime = 3;
    float phaseTime = 0;
    public bool bossOn = false;
    public int stage = 1;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time < 15)
        {
            PhaseOne(time);
        } 
        else if(time < 35)
        {
            PhaseTwo(time);
        }
        else
        {
            bossOn = true;
        }
    }
    void PhaseOne(float time)
    {
        if (time > spawnTime)
        {
            Instantiate(ast, new Vector3(9, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
            spawnTime += Random.Range(2, 6);
        }
        if (time > enemySpawnTime)
        {
            int type = Random.Range(0, 3);
            Instantiate(enemies[type], new Vector3(9, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
            enemySpawnTime += Random.Range(3, 8);
        }
    }
    void PhaseTwo(float time)
    {
        int patternNumber = Random.Range(0, 3);
        if(time > phaseTime)
        {
            phaseTime = time + 5f;
            if (patternNumber == 0)
            {
                PatternOne();
            } 
            else if (patternNumber == 1)
            {
                PatternTwo();
            }
            else if (patternNumber == 2)
            {
                PatternThree();
            }
        }
    }

    void PatternOne()
    {
        for (float i = 0; i < 3; i += 1.0f)
        {
            Instantiate(enemies[0], new Vector3(9 + i/3, -4.0f + i, 0), Quaternion.identity);
            Instantiate(enemies[0], new Vector3(9 + i/3, 4.0f - i, 0), Quaternion.identity);
        }
    }

    void PatternTwo()
    {
        for (float i = 8; i >= 0; i -= 2.0f)
        {
            Instantiate(enemies[2], new Vector3(9 + i/3, -4.0f + i, 0), Quaternion.identity);
        }
    }

    void PatternThree()
    {
        for (float i = 0; i < 15; i += 1.0f)
        {
            Instantiate(enemies[1], new Vector3(9 + i/2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
        }
    }

    public void PauseAction()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MainMenuAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }
}
