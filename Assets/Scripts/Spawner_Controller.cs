using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    [Header("Components")]
    public GameObject enemyPrefab;
    public GameObject barbarianPrefab;
    public GameObject knightPrefab;
    public Transform[] spawnPoints;

    [Header("Gameplay")]
    public float interval;
    void Start()
    {
        InvokeRepeating("spawn", 0.5f, interval);
    }

    private void spawn() {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity);
        int randPos2 = Random.Range(0, spawnPoints.Length);
        GameObject newBarbarian = Instantiate(barbarianPrefab, spawnPoints[randPos2].position, Quaternion.identity);
        int randPos3 = Random.Range(0, spawnPoints.Length);
        GameObject newKnight = Instantiate(knightPrefab, spawnPoints[randPos3].position, Quaternion.identity);
    }
}
