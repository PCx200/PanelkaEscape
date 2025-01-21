using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWireCamera : MonoBehaviour
{
    public GameObject wireCamera;
    public WireManager wireManager;
    public Inventory inventory;
    private void Update()
    {
        if (wireManager.finishTask)
        {
            DisableCamera();
            inventory.RemoveInventoryItem("Gloves");
            inventory.AddItem("gloves_disableTask");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DisableCamera();
    }

    private void DisableCamera()
    {
        wireCamera.SetActive(false);
    }
}
