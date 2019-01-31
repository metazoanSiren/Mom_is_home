using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (Input.GetKeyDown("return"))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }

}
