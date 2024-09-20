using System;

using Cinemachine;

using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    
    private CinemachineVirtualCamera _cinemachine;
    private float _shakerTimer;
    private CinemachineBasicMultiChannelPerlin _perlin;
    private float _startIntensity;
    private float _totalShakeTime;
    
    [SerializeField]
    private float maxIntensity;
    [SerializeField]
    private float shakeTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
 
    private void Start()
    {
        _cinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera()
    {
        _startIntensity = maxIntensity;
        _totalShakeTime = shakeTime;
        _shakerTimer = shakeTime;
        
        _perlin = _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _perlin.m_AmplitudeGain = maxIntensity;
    }

    private void Update()
    {
        if (_shakerTimer > 0)
        {
            _shakerTimer -= Time.deltaTime;
            _perlin.m_AmplitudeGain = Mathf.Lerp(_startIntensity, 0, 1 - _shakerTimer/ _totalShakeTime);
        }
    }
}