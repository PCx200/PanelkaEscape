using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalScene : MonoBehaviour
{
    [SerializeField] string _sceneName;
    void Start()
    {
        StartCoroutine(FinalSceneLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FinalSceneLoad()
    { 
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(_sceneName);
    }
}
