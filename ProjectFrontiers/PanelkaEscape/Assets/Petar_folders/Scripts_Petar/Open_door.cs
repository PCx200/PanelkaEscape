using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_door : MonoBehaviour
{

    public GameObject text_to_display;                                  //The text you want to display
    public bool has_key = false;                                        //Object you need
    public Animator door_animator;                                      //Animator you are using
    public string animation_to_play;                                    //Im not explaining that
    private bool door_state = false;                                    //Tells if door is open or closed


    private void Start()
    {
        if (text_to_display != null)                                    //Make sure the text isn't already visible
        {
            text_to_display.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)                          //Remove text when the player leaves
    {
        if (other.CompareTag("Player"))
        {
            text_to_display.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    { 
        if (other.CompareTag("Player"))                                 //Display text while in the trigger box
            {
                if (text_to_display != null)
                {
                    text_to_display.SetActive(true);
                }
            }
        if (Input.GetKeyDown(KeyCode.E))                                //Detect player input
        {
            if (!door_state)                                            //Open door
            {
                door_animator.SetBool(animation_to_play, true);
                door_state = true;
            }
            else                                                        //Close door
            {   
                door_animator.SetBool(animation_to_play, false);
                door_state = false;
            }
        }
    }
}

