using Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeAmplitude = 1.2f;
    [SerializeField] float shakeFrequency = 2.0f;


    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin virtualCameraNosie;

    private void Start()
    {
        if (virtualCamera != null)
        {
            virtualCameraNosie = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    public IEnumerator ShakeCamera()
    {
        virtualCameraNosie.m_AmplitudeGain = shakeAmplitude;
        virtualCameraNosie.m_FrequencyGain = shakeFrequency;
        yield return new WaitForSecondsRealtime(1);
        virtualCameraNosie.m_AmplitudeGain = 0;
    }
}