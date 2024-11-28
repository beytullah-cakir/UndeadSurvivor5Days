using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    private CinemachineBasicMultiChannelPerlin noise;
    private float shakeTimer;

    public static CameraShake instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                StopShake();
            }
        }
    }

    public void StartShake(float intensity, float duration)
    {
       
        noise.AmplitudeGain = intensity;
        shakeTimer = duration;
    }

    public void StopShake()
    {
        
        noise.AmplitudeGain = 0f;
    }
}
