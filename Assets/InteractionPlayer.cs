using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : MonoBehaviour
{
    //public KeyCode interactKey = KeyCode.Space;
    private NPCDialogue currentNPC;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (currentNPC != null && Input.GetKeyDown(interactKey))
        if (currentNPC != null && Input.GetMouseButtonDown(1))
        {
            if (!currentNPC.Dialogo.activeInHierarchy)
            {
                animator.SetTrigger("Interact");
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
