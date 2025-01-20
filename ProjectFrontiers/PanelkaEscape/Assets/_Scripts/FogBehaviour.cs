using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem fog;
    private void Awake()
    {
        fog.Stop();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("puf");
            StartCoroutine(PlayFog());

        }
    }
    public IEnumerator PlayFog()
    {
        fog.Play();
        yield return new WaitForSeconds(1.0f);
        fog.Stop();
    }

}
