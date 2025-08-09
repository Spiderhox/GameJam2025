using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.Space;
    private NPCDialogue currentNPC;

    void Update()
    {
        if (currentNPC != null && Input.GetKeyDown(interactKey))
        {
            if (!currentNPC.Dialogo.activeInHierarchy)
            {
                currentNPC.StartDialogue();
            }
            else
            {
                currentNPC.ContinueDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NPCDialogue npc = other.GetComponent<NPCDialogue>();
        if (npc != null)
        {
            currentNPC = npc;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        NPCDialogue npc = other.GetComponent<NPCDialogue>();
        if (npc != null && npc == currentNPC)
        {
            currentNPC.EndDialogue();
            currentNPC = null;
        }
    }

}
