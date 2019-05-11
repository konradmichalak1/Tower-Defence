using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// GameMaster script
/// </summary>
public class WaveSpawner : MonoBehaviour {



    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;
    
    public float timeBetweenWaves = 3f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        //Spawn new wave only if there is no enemies.
        if(EnemiesAlive > 0)
        {
            return;
        }

        //Wavespawn counter & UI timer update
        if(countdown <= 0f)
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
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i =0; i< wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("LEVEL COMPLETE!");
            this.enabled = false; //disable this script
        }
    }

    /// <summary>
    /// Instantiate enemy object
    /// </summary>
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
