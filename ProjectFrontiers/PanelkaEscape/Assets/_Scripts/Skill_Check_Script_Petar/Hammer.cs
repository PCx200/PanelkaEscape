using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
   // public GameObject text_to_display;                                  //The text you want to display
    public SkillCheck_ChargeUp SkillCheck_ChargeUp;
    public Inventory inventory;
    public GameObject trigger_to_activate;
    private void Update()
    {
        if (inventory.HasItem("Hammer"))
        {
            SkillCheck_ChargeUp.has_hammer = true;
            gameObject.SetActive(false);
            trigger_to_activate.SetActive(true);
        }
    }

    //private void OnTriggerStay()                                        //Check for player input
    //{
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        //gameObject.SetActive(false);
    //        //text_to_display.SetActive(false);
    //        interactable_to_activate.SetActive(true);
    //    }
    //}


    //private void OnTriggerEnter(Collider other)                         //Display text while in the trigger box
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (text_to_display != null)
    //        {
    //            text_to_display.SetActive(true);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)                          //Remove text when the player leaves
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        text_to_display.SetActive(false);
    //    }
    //}
}
