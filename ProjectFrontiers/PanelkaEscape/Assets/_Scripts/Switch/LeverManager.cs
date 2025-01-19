using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool[] LeverState = new bool[3];
    public bool IsPuzzleSolved = false;

    [SerializeField] private float _animationDuration = 1f;

    private int _currentStep = 0;
    private int[] _solutionSequence = { 1, 2, 0 };

    [SerializeField] Camera _camera;

    [SerializeField] GameObject obtainableObj;
    [SerializeField] Transform keySpawn;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var lever = transform.GetChild(i).GetComponent<Lever>();
            lever.LeverManager = this;
            lever.LeverNumber = i;

            lever.transform.rotation = Quaternion.Euler(0,270f,0);
        }
    }

    public void OnLeverClicked(int leverNumber)
    {
        if (leverNumber == _solutionSequence[_currentStep])
        {
            LeverState[leverNumber] = true;
            MoveLever(leverNumber, true);
            _currentStep++;

            if (_currentStep == _solutionSequence.Length)
            {
                IsPuzzleSolved = true;
                Instantiate(obtainableObj, keySpawn.position, keySpawn.rotation);
                //Debug.Log("Puzzle Solved!");
                return;
            }
        }
        else
        {
            ResetLevers();
        }
    }

    private void ResetLevers()
    {
        for (int i = 0; i < LeverState.Length; i++)
        {
            LeverState[i] = false;
            MoveLever(i, false);
        }
        _currentStep = 0;
        //Debug.Log("Sequence Reset!");
    }

    private void MoveLever(int leverNumber, bool isActivated)
    {
        var lever = transform.GetChild(leverNumber);

        Quaternion targetRotation = isActivated
            ? Quaternion.Euler(270f, 270, 0)
            : Quaternion.Euler(0, 270, 0); 

        StartCoroutine(AnimateLeverMovement(lever, targetRotation));
    }

    private IEnumerator AnimateLeverMovement(Transform lever, Quaternion targetRotation)
    {
        Quaternion startingRotation = lever.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < _animationDuration)
        {
            lever.rotation = Quaternion.Lerp(startingRotation, targetRotation, elapsedTime / _animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lever.rotation = targetRotation;
    }

    private void SetLeversEnabled(bool pEnabled)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var lever = transform.GetChild(i).GetComponent<BoxCollider>();
            lever.enabled = pEnabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SetLeversEnabled(true);
    }

    private void OnTriggerExit(Collider other)
    {
        SetLeversEnabled(false);
        _camera.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        _camera.enabled = true;
        if (IsPuzzleSolved)
        {
            SetLeversEnabled(false);
            _camera.enabled = false;
        }

    }
}
