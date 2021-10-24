using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private float startTimer;
    [SerializeField] private float timerWaitFor = 2f;

    [SerializeField] ParticleSystem celebration;
    bool hasChildren = true;

    void Update()
    {
        if (transform.childCount == 0)
        {
            celebration.Play();
            startTimer += Time.deltaTime;
            hasChildren = false;
        }

        if (!hasChildren && startTimer >= timerWaitFor)
        {
            celebration.Stop(false,ParticleSystemStopBehavior.StopEmittingAndClear);
            startTimer = timerWaitFor;
        }
    }
}