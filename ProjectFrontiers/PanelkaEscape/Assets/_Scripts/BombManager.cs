using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] public float[] timeToExplode = new float[3];
    [SerializeField] public float timeLeft;
    [SerializeField] private int currentStage = 0;
    [SerializeField] AudioSource[] audioSources = new AudioSource[2];

    private float startTime;

    [SerializeField] FogBehaviour[] fogBehaviour;

    public FloorCheker floorCheker;

    public GameObject deathScreen;

    public GameObject questCanvas;

    public GameObject player;

    public GameObject rock;
    private void Start()
    {
        audioSources[0].Play();
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
        StageChecker();
    }

    private void StageChecker()
    {
        if (currentStage == 1 && floorCheker.stageChecker[0] == 0)
        {
            StartCoroutine(Die()); 
            //Debug.Log("You died");
        }
        if (currentStage == 2 && floorCheker.stageChecker[1] == 1)
        {
            StartCoroutine(Die());
            //Debug.Log("You died");

        }
        if (currentStage == 2)
        {
            rock.SetActive(true);
            //set active some rocks
        }
        if(currentStage == 3)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        deathScreen.SetActive(true);
        questCanvas.SetActive(false);
        player.SetActive(false);
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

                if (currentStage == 1)
                {
                    audioSources[0].Play();
                }
                if (currentStage == 2) 
                {
                    audioSources[1].Play();
                }

            }
        }
        else
        {
            timeLeft = 0;
        }
    }

    
}