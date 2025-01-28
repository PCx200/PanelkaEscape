using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameObject audioObject = new GameObject("One Shot Audio");
        audioObject.transform.position = transform.position;

        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = audioClip;

        audioSource.Play();

        Destroy(audioObject, audioClip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
