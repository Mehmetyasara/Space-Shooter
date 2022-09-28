using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public int startWait;
    public float waveWait;

    public Text scoreText;
    public int score;
    public Text restartText;
    public Text gameOverText;
    public Text quitText;

    private bool gameOver;
    private bool restart;
    private bool quit;

    private void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

        }
        if (quit == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnValues()
    {

        yield return new WaitForSeconds(startWait);
        while (true)
        {

            if (gameOver)
            {
                yield break;
            }
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                quitText.text = "Press 'Q' for Quit";
                quit = true;
            }
        }
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score" + score;

    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = " ";
        gameOver = false;
        restart = false;
        quit = false;
        StartCoroutine(SpawnValues());
    }


}
