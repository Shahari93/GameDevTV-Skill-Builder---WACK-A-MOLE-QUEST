using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    Text timerText;
    float elapsedTime;
    WaitForSecondsRealtime WaitForSecondsRealtime;
    float secondsToWait = 0.2f;

    void Start()
    {
        WaitForSecondsRealtime = new WaitForSecondsRealtime(secondsToWait);
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = Mathf.RoundToInt(elapsedTime).ToString();
    }

    public IEnumerator ResetTimer()
    {
        yield return WaitForSecondsRealtime;
        elapsedTime = 0;
        timerText.text = elapsedTime.ToString();
    }

    public IEnumerator SlowDownTime()
    {
        Time.timeScale = 0.3f;
        yield return WaitForSecondsRealtime;
        Time.timeScale = 1f;
    }
}