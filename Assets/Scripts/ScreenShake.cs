using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cineMachineBrain;

    public void StartScreenShake(float amplitude, float frequency, float length)
    {
        if (cineMachineBrain == null) Debug.LogError("Missing cinemachine reference");

        else
        {
            cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
            cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

            Invoke(nameof(ResetScreenShake), length);
        }
    }

    private void ResetScreenShake()
    {
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }
}
