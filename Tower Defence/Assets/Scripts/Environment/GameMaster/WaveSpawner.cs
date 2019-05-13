using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// GameMaster script
/// </summary>
public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;


    public Transform spawnPoint;
    
    public float timeBetweenWaves = 3f;
    /// <summary>
    /// Time that is needed to start first wave.
    /// </summary>
    public float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;


    private void Update()
    {

        //Spawn new wave only if there is no enemies.
        if(EnemiesAlive > 0)
        {
            return;
        }

        //Winning level
        if (waveIndex == waves.Length && EnemiesAlive <=0)
        {
            gameManager.WinLevel();
            this.enabled = false; //disable this script
        }

        //Wavespawn counter & UI timer update
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //Counter always will always have positive value

        waveCountdownText.text = string.Format("{0:0.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        EnemiesAlive = 0;
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        foreach(var e in wave.Enemies)
        {
            EnemiesAlive += e.count;
        }

        //EnemiesAlive = wave.count;

        foreach (var e in wave.Enemies)
        {
            for (int i = 0; i < e.count; i++)
            {
                SpawnEnemy(e.enemy);
                yield return new WaitForSeconds(1f / e.rate);
            }
        }

        //for (int i =0; i< wave.count; i++)
        //{
        //  SpawnEnemy(wave.enemy);
        //yield return new WaitForSeconds(1f / wave.rate);
        //}

        waveIndex++;

    }

    /// <summary>
    /// Instantiate enemy object
    /// </summary>
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
