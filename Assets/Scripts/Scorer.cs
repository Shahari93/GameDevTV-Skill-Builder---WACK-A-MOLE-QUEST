using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    [SerializeField] private float startTimer;
    [SerializeField] private float timerWaitFor = 2f;

    [SerializeField] ParticleSystem celebration;
    [SerializeField] SpawnCubesAtRandom spawner;
    [SerializeField] Timer timer;
    bool hasChildren = true;

    void Update()
    {
        if (spawner.enemies.Count <= 0)
        {
            celebration.Play();
            startTimer += Time.deltaTime;
            hasChildren = false;
        }

        if (!hasChildren && startTimer >= timerWaitFor)
        {
            celebration.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            startTimer = timerWaitFor;
            StartCoroutine(timer.ResetTimer());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}