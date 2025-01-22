using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AutoAdvanceDialog : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    private void Start()
    {
        if (dialogueRunner == null)
        {
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        }
    }

    [YarnCommand("autoadvance")]
    public void AutoAdvance(float waitTime)
    {
        //Debug.Log("FOR THE DRAGON!");
        StartCoroutine(AutoAdvanceCoroutine(waitTime));
    }

    private System.Collections.IEnumerator AutoAdvanceCoroutine(float waitTime)
    {
        //Debug.Log("FOR THE DRAGON! 2");
        yield return new WaitForSeconds(waitTime);

        // Signal the Dialogue View to advance to the next line
        dialogueRunner.dialogueViews[0].UserRequestedViewAdvancement();
    }
}
