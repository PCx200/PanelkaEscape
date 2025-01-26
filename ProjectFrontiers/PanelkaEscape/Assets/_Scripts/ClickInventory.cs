using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ClickInventory : MonoBehaviour
{

    [SerializeField] private bool _isOpened = false;
    [SerializeField] private Transform[] inventoryItems; // Array to assign child objects manually

    public void ClickOnBag()
    {
        _isOpened = !_isOpened;

        // Toggle active state of inventory items
        foreach (var item in inventoryItems)
        {
            if (item != null)
            {
                item.gameObject.SetActive(_isOpened);
            }
        }
    }
}
