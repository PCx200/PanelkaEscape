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
    [SerializeField] GameObject key;
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
            if (key != null)
            {
                key.SetActive(true);
            }
            animator.SetBool(animation_to_trigger, true);
        }
    }
}
