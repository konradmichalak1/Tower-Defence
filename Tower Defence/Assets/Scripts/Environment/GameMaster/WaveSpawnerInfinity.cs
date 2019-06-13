using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// GameMaster script
/// </summary>
public class WaveSpawnerInfinity : MonoBehaviour {

    public static int EnemiesAlive = 0;
    public static int MoneyReward=0;
    /// <summary>
    /// Enemies
    /// </summary>
    [Header("Enemies")]
    public GameObject EnemyFast;
    public GameObject EnemySimple;
    public GameObject EnemyTough;
    public GameObject EnemyBoss;


    [Header("Others")]
    public Transform spawnPoint;
    
    public float timeBetweenWaves = 3f;
    /// <summary>
    /// Time that is needed to start first wave.
    /// </summary>
    public float countdown = 2f;

    public Text waveCountdownText;
    public Text waveNumberText;

    public GameManager gameManager;

    private int waveIndex = 0;


    /// <summary> Neccesery to calculate and not change enemies life </summary>
    public void SetEnemiesLifeToDefault()
    {
        EnemySimple.GetComponent<EnemyController>().startHealth = 100;
        EnemyTough.GetComponent<EnemyController>().startHealth = 400;
        EnemyFast.GetComponent<EnemyController>().startHealth = 20;
        EnemyBoss.GetComponent<EnemyController>().startHealth = 2000;
    }



    private void Start()
    {
        SetEnemiesLifeToDefault();
        waveNumberText.text = "Wave: 0";
    }

    private void Update()
    {

        //Spawn new wave only if there is no enemies.
        if(EnemiesAlive > 0)
        {
            return;
        }

        //Wavespawn counter & UI timer update
        if (countdown <= 0f)
        {
            GenerateWave();
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //Counter always will always have positive value

        waveCountdownText.text = string.Format("{0:0.00}", countdown);
    }

    /// <summary>
    /// The main function that calculate next wave
    /// </summary>
    /// <returns></returns>
    private Wave GenerateWave()
    {
        Wave wave = new Wave();

        EnemySimple.GetComponent<EnemyController>().startHealth =
            EnemySimple.GetComponent<EnemyController>().startHealth + (5*waveIndex * EnemySimple.GetComponent<EnemyController>().startHealth / 100);

        EnemyFast.GetComponent<EnemyController>().startHealth =
            EnemyFast.GetComponent<EnemyController>().startHealth + (5*waveIndex * EnemyFast.GetComponent<EnemyController>().startHealth / 100);

        EnemyTough.GetComponent<EnemyController>().startHealth =
            EnemyTough.GetComponent<EnemyController>().startHealth + (5*waveIndex * EnemyTough.GetComponent<EnemyController>().startHealth / 100);

        EnemyBoss.GetComponent<EnemyController>().startHealth =
            EnemyBoss.GetComponent<EnemyController>().startHealth + (5*waveIndex * EnemyBoss.GetComponent<EnemyController>().startHealth / 100);

        List<EnemyInWave> enemies = new List<EnemyInWave>();

        if((waveIndex+1)%5==0 && waveIndex > 0)
        {
            enemies.Add(new EnemyInWave(EnemyBoss, 1, 5f));
        }

        int rng = Random.Range(1, 8);
        int rngSimpleNr = Random.Range(3, waveIndex+3);
        int rngToughNr = Random.Range(1, waveIndex + 1);
        int rngFastNr = Random.Range(6, waveIndex + 6);
        switch (rng){
            case 1:
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr, 2f));
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr, 1f));
                enemies.Add(new EnemyInWave(EnemyFast, rngFastNr, 3f));
                break;

            case 2:
                enemies.Add(new EnemyInWave(EnemyFast, rngFastNr * 3, 4f));
                break;

            case 3:
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr, 1f));
                enemies.Add(new EnemyInWave(EnemyFast, rngFastNr*2, 1.5f));
                break;

            case 4:
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr*3, 3f));
                break;

            case 5:
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr * 3, 1.5f));
                break;

            case 6:
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr, 1.25f));
                enemies.Add(new EnemyInWave(EnemyFast, rngFastNr, 2f));
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr/2, 2f));
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr, 0.75f));
                break;

            case 7:
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr/2, 2f));
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr, 1.25f));
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr, 1f));
                break;
            case 8:
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr / 2, 2f));
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr/2, 1.25f));
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr/2, 1f));
                enemies.Add(new EnemyInWave(EnemyFast, rngFastNr, 3f));
                enemies.Add(new EnemyInWave(EnemySimple, rngSimpleNr / 2, 1.25f));
                enemies.Add(new EnemyInWave(EnemyTough, rngToughNr / 2, 1f));
                break;
        }




        wave.Enemies = enemies;
        return wave;
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds = waveIndex;
        waveNumberText.text = "Wave: " + (waveIndex+1);

        EnemiesAlive = 0;

        Wave wave = new Wave();
        wave = GenerateWave();


        foreach (var e in wave.Enemies)
        {
            EnemiesAlive += e.count;
        }


        foreach (var e in wave.Enemies)
        {
            for (int i = 0; i < e.count; i++)
            {
                
                SpawnEnemy(e.enemy);
                yield return new WaitForSeconds(1f / e.rate);
            }
        }

        SetEnemiesLifeToDefault();
        waveIndex++;

        MoneyReward += (waveIndex+1) * Random.Range(2,8);
    }

    /// <summary>
    /// Instantiate enemy object
    /// </summary>
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
