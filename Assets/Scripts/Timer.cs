using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText; 
    float elapsedTime;
    
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        
    }
}
