using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparcleBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float playDuration;
    [SerializeField] private float randomStopDuration;
    [SerializeField] float[] stopValues = new float[2];

    void Start()
    {
        StartCoroutine(LoopParticles());
    }

    IEnumerator LoopParticles()
    {
        while (true)
        {
            randomStopDuration = Random.Range(stopValues[0], stopValues[1]);
            particles.Play();
            yield return new WaitForSeconds(playDuration);

            particles.Stop();
            yield return new WaitForSeconds(randomStopDuration);
        }
    }
}
