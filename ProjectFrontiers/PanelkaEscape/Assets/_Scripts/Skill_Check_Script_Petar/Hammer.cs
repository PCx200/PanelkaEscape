using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
   // public GameObject text_to_display;                                  //The text you want to display
    public SkillCheck_ChargeUp SkillCheck_ChargeUp;
    public GameObject interactable_to_activate;

    //private void Start()
    //{
    //    if (text_to_display != null)                                    //Make sure the text isn't already visible
    //    {
    //        text_to_display.SetActive(false);
    //    }
    //}

    private void OnTriggerStay()                                        //Check for player input
    {
        if (Input.GetKey(KeyCode.E))
        {
            SkillCheck_ChargeUp.has_hammer = true;
            //gameObject.SetActive(false);
            //text_to_display.SetActive(false);
            interactable_to_activate.SetActive(true);
        }
    }
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
