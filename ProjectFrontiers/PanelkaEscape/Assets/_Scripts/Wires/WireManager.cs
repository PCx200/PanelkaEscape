using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour
{
    public UnpoweredWireStat red;
    public UnpoweredWireStat green;
    public UnpoweredWireStat blue;
    public UnpoweredWireStat yellow;

    public bool finishTask = false;
    public Animator animator;
    public string animation_to_trigger;

    void Update()
    {
        if (red.connected && green.connected && blue.connected && yellow.connected)
        {
            finishTask = true;
            
        }

        if (finishTask)
        { 
            animator.SetBool(animation_to_trigger, true);
        }
    }
}
