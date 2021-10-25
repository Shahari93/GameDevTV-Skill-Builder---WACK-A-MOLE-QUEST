using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubesAtRandom : MonoBehaviour
{
    [HideInInspector] public int enemiesCount;
    [SerializeField] private Transform[] spawnPoints;
    public List<GameObject> enemies;

    [SerializeField] float waitTime = 2f;
    float startTime = 0;

    private void Start()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            SetEnemyActiveState(enemies[i].gameObject, false);
        }
        enemiesCount = enemies.Count;
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
            if (enemiesCount >= 0)
            {
                foreach (var enemy in enemies)
                {
                    Vector3 offset = new Vector3(transform.position.x, .5f, transform.position.z);
                    GameObject enemySpawn = Instantiate(enemy.gameObject, ReturnRandSpawnPoint().position + offset, Quaternion.identity);
                    SetEnemyActiveState(enemySpawn, true);
                    startTime = 0;
                    StartCoroutine(TurnOffGameObject(enemySpawn));
                }
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