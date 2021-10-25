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


    WaitForSecondsRealtime WaitForSeconds;
    [SerializeField] float waitTimeForCoroutine = 1.5f;

    private void Start()
    {
        WaitForSeconds = new WaitForSecondsRealtime(waitTimeForCoroutine);
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
                    SetEnemyActiveState(enemy.gameObject, true, enemy.transform.position + offset, enemy.transform.rotation);
                    startTime = 0;
                    StartCoroutine(TurnOffGameObject(enemy.gameObject));
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

    private void SetEnemyActiveState(GameObject go, bool isActive, Vector3 pos, Quaternion quaternion)
    {
        go.SetActive(isActive);
        go.transform.position = ReturnRandSpawnPoint().position;
        go.transform.rotation = quaternion;
    }

    IEnumerator TurnOffGameObject(GameObject go)
    {
        yield return WaitForSeconds;
        SetEnemyActiveState(go, false);
    }
}