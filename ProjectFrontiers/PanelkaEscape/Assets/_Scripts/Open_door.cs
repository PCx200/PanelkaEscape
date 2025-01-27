using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_door : MonoBehaviour
{

    public Animator door_animator;                                      //Animator you are using
    public string animation_to_play;                                    //Im not explaining that


    private void Start()                                                //Open door
    {
        door_animator.SetBool(animation_to_play, true);
    }
}

