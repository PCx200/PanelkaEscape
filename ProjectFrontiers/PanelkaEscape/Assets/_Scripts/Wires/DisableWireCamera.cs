using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWireCamera : MonoBehaviour
{
    public GameObject wireCamera;
    public GameObject bagButton;
    public WireManager wireManager;
    public Inventory inventory;
    private void Update()
    {
        if (wireManager.finishTask)
        {
            StartCoroutine(DisableCamera(1f));
            inventory.RemoveInventoryItem("Gloves");
        }
    }
    private void OnTriggerExit(Collider other)
    {
       StartCoroutine(DisableCamera(0.2f));
    }

    private IEnumerator DisableCamera(float delay)
    {
        yield return new WaitForSeconds(delay);
        wireCamera.SetActive(false);
        bagButton.SetActive(true);
    }
}
