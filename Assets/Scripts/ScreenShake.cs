using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cineMachineBrain;

    public void Shake(float strength, float length)
    {
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = strength;
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = strength;

        Invoke(nameof(ResetNoise), length);
    }

    private void ResetNoise()
    {
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        cineMachineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }
}
