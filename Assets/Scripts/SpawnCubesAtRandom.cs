using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubesAtRandom : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    public List<GameObject> enemies;

    float startTime = 0;
    float waitTime = 2f;

    private void Start()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            SetEnemyActiveState(enemies[i].gameObject, false);
        }
    }

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        startTime += Time.deltaTime;
        if (startTime >= waitTime)
        {
            foreach (var enemy in enemies)
            {
                GameObject enemySpawn = Instantiate(enemy.gameObject, ReturnRandSpawnPoint().position, Quaternion.identity);
                SetEnemyActiveState(enemySpawn, true);
                startTime = 0;
                StartCoroutine(TurnOffGameObject(enemySpawn));
            }
        }
    }

    private Transform ReturnRandSpawnPoint()
    {
        int r = Random.Range(0, spawnPoints.Length);
        return spawnPoints[r];
    }

    private void SetEnemyActiveState(GameObject go, bool isActive)
    {
        go.SetActive(isActive);
    }

    IEnumerator TurnOffGameObject(GameObject go)
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SetEnemyActiveState(go, false);
    }
}