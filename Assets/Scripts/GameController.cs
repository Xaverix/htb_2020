using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI scoretext;
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    public List<GameObject> hearts;
    public GameObject gameOverScreen;

    public static float enemySpeed;
    private float _enemySpawnSpeed;
    private float _spawnT;
    private int lives = 3;

    public static bool isStarted;

    private static GameController _instance;

    private void Awake()
    {
        _instance = this;

        enemySpeed = 1.3f;
        _enemySpawnSpeed = 2.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0 || !isStarted)
        {
            return;
        }
        
        enemySpeed += 0.02f * Time.deltaTime;
        _enemySpawnSpeed -= 0.02f * Time.deltaTime;

        _enemySpawnSpeed = Mathf.Clamp(_enemySpawnSpeed, 0.3f, 1000f);

        _spawnT += Time.deltaTime;

        if (_spawnT >= _enemySpawnSpeed)
        {
            SpawnEnemy();
            _spawnT -= _enemySpawnSpeed;
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject enemy = enemies[Random.Range(0, enemies.Count)];

        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }

    public static void Damage()
    {
        if (_instance.lives == 0)
        {
            return;
        }
        
        _instance.hearts[3 - _instance.lives].gameObject.SetActive(false);
        _instance.lives--;

        if (_instance.lives == 0)
        {
            enemySpeed = 0;
            _instance._enemySpawnSpeed = 100000f;
            isStarted = false;
            _instance.gameOverScreen.SetActive(true);
        }
    }

    public static void AddScore()
    {
        score += 100;
        _instance.scoretext.text = score.ToString();
    }
}
