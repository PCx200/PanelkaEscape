using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCheck_ChargeUp : MonoBehaviour
{
    private float charge_value = 0;                                 //The current charge
    private float charge_direction = 1;                             //The directoin in which the charge moves
    private bool legs_broken = false;                               //Bro :(
    
    public float charge_speed = 100;                                //The speed at which the charge grows                            
    public float goal_up_range = 70;                                //The range of the player challenge
    public float goal_down_range = 50;
    public float difficulty = 30;                                   //Determines the size of the gap
    public bool has_hammer = false;                                 //check for the required item

    public GameObject full_slider;                                  //Parent object for all sliders
    public Slider charge_slider;                                    //Slider for the current charge
    public Slider bottom_goal;                                      //Slider for the bottom range of the goal
    public Slider top_goal;                                         //Slider for the top range of the goal
    public ThirdPersonController player;                            //Get the player controller
    private void OnEnable()
    {
        if (full_slider != null)
        { 
            full_slider.SetActive(true);
        }

        if (charge_slider != null)                                  //Adjust the used slider to fit the script
        {
            charge_slider.minValue = 0;                             
            charge_slider.maxValue = 100;  
        }

        if (!has_hammer)                                            // lower difficulty if has hammer
        {
            difficulty = 2;
            charge_speed = 400;
        }
        else
        {
            difficulty = 10;
            charge_speed = 100;
        }

        if (bottom_goal != null && top_goal != null)                //Randomizing the goal gap on start
        {
            goal_down_range = Random.Range(0, 100 - difficulty);
            bottom_goal.value = goal_down_range;
        
            goal_up_range = goal_down_range + difficulty;
            top_goal.value = goal_up_range;    
        }
        player.MoveSpeed = 0;
        player.SprintSpeed = 0;
    }
    private void FixedUpdate()
    {   
        charge_value = charge_value +((charge_direction * charge_speed)* Time.deltaTime) ;                      //Charge up the Charge_Value
        if (charge_value >= 100 || charge_value <= 0)
        {
            charge_direction = charge_direction * -1;               //Change the Charge_Value direction
            
        }
     
        if (charge_slider != null)                                  //Change the value of the slider
        {
            charge_slider.value = charge_value;
        }

        
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))                         //Detect input from player
        {
            Hit();
        } 
    }

    void Hit()                                                      //Checking if the player has a skill issue
    {
         if (charge_value > goal_down_range && charge_value < goal_up_range)
         {
            Debug.Log("Succsess");
            gameObject.SetActive(false);
            full_slider.SetActive(false);
            player.MoveSpeed = 2f;
            player.SprintSpeed = 5.3f;
            if (legs_broken)
            {
                player.MoveSpeed = 1.5f;
                player.SprintSpeed = 1.5f;
            }
        }

        else 
         {
            Debug.Log("Failed");                                    

            if (has_hammer)                                         
            {
                goal_down_range = Random.Range(0, 100 - difficulty);//Randomize the gap if the player has a skill issue
                goal_up_range = goal_down_range + difficulty;


                if (bottom_goal != null && top_goal != null)        //Move the sliders accordingly
                {
                    top_goal.value = goal_up_range;
                    bottom_goal.value = goal_down_range;

                }
            }
            else
            { 
                gameObject.SetActive(false);
                full_slider.SetActive(false);
                player.MoveSpeed = 1.5f;
                player.SprintSpeed = 1.5f;
                player.JumpHeight = 0.01f;
                legs_broken = true;
            }
         }
    }
}