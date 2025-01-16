using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public LeverManager LeverManager;
    public int LeverNumber;

    private void OnMouseDown()
    {
        if (!LeverManager.IsPuzzleSolved)
        {
            LeverManager.OnLeverClicked(LeverNumber);
            Debug.Log(LeverNumber);
        }
    }
}
