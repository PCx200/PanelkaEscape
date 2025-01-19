using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactable_script_cock_and_ball_torture : MonoBehaviour
{
    public GameObject text_to_display;                                  //The text you want to display
    public GameObject object_to_activate;
    public SkillCheck_ChargeUp hammer_check;

    private void Start()
    {
        if (text_to_display != null)                                    //Make sure the text isn't already visible
        { 
            text_to_display.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)                         //Display text while in the trigger box
    {
        if (other.CompareTag("Player"))
        {
            if (text_to_display != null)
            {
                text_to_display.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)                          //Remove text when the player leaves
    {
        if (other.CompareTag("Player"))
        {
            text_to_display.SetActive(false);
        }
    }

    private void OnTriggerStay()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        { 
            object_to_activate.SetActive(true);
            text_to_display.SetActive(false);
            if (hammer_check.has_hammer == false)
            { 
                gameObject.SetActive(false);
            }
        }
    }
}
