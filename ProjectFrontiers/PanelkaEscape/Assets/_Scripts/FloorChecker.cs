using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheker : MonoBehaviour
{
    public float[] stageChecker = new float[2];
    private void OnTriggerEnter(Collider other)
    {
        stageChecker[0]=1;
    }

    private void OnTriggerStay(Collider other)
    {
        stageChecker[1] = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        stageChecker[1] = 0;
    }
}
