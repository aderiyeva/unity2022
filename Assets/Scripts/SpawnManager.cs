using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform target;


    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float enemySpawnTime = 5f; 
    [SerializeField] private bool spawnEnemies = true;

    [SerializeField] private GameObject _rainDropPrefab;
    [SerializeField] private float rainSpawnTime = 0.5f; 
    [SerializeField] private bool spawnRainDrops = true;

    // Spawn enemy above the player every couple of seconds
    IEnumerator EnemySpawnRoutine()
    {
        Vector3 spawnPos = Vector3.zero;
        while (spawnEnemies)
        {
            yield return new WaitForSeconds(enemySpawnTime);
            spawnPos.x = Random.Range (target.position.x - 2f , target.position.x + 2f);
            spawnPos.y = Random.Range (target.position.y + 3f , target.position.y + 5f);
            Instantiate (_enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Spawn raindrops randomly above the map every couple of seconds
    IEnumerator RainSpawnRoutine()
    {
        Vector3 spawnPos = Vector3.zero;
        while (spawnRainDrops)
        {
            yield return new WaitForSeconds(rainSpawnTime);
            spawnPos.x = Random.Range (-40f , 40f);
            spawnPos.y = 50f;
            Instantiate (_rainDropPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(RainSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
