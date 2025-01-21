using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BombManager : MonoBehaviour
{
    [SerializeField] public float[] timeToExplode = new float[3];
    [SerializeField] public float timeLeft;
    [SerializeField] private int currentStage = 0;

    private float startTime;

    [SerializeField] FogBehaviour[] fogBehaviour;

    private void Start()
    {
        fogBehaviour = FindObjectsOfType<FogBehaviour>();
        if (timeToExplode.Length > 0)
        {
            timeLeft = timeToExplode[0];
            startTime = Time.time;
        }
    }

    private void Update()
    {
        BombExplosion();
    }

    private void BombExplosion()
    {
        if (currentStage < timeToExplode.Length)
        {
            timeLeft = timeToExplode[currentStage] - (Time.time - startTime);


            if (timeLeft <= 0)
            {
                currentStage++;
                startTime = Time.time;
                StartCoroutine(fogBehaviour[0].PlayFog());
                StartCoroutine(fogBehaviour[1].PlayFog());
            }
        }
        else
        {
            timeLeft = 0;
        }
    }
}