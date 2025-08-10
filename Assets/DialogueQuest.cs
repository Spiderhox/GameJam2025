using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuest : MonoBehaviour
{
    public NPCDialogue npcReceiver;
    public NPCDialogue npcGiver;

    public string[] lockedDialogue;
    public string[] questDialogue;
    public string[] unlockDialogue;
    public string[] aknowledgeDialogue;

    public bool unlockDialogues = false;
    public bool completeQuest= false;

    private void Start()
    {
        npcReceiver.dialogueLines = lockedDialogue;
        npcGiver.dialogueLines = questDialogue;
        npcGiver.OnCompleteDialogue += UnlockText;
        npcReceiver.OnCompleteDialogue += CompleteQuest;
    }

    public void UnlockText() 
    {
        if (!completeQuest) 
        {
            npcReceiver.dialogueLines = unlockDialogue;
            unlockDialogues = true;
        } 
        else 
        {
            npcGiver.gameObject.SetActive(false);
        }
    }

    public void CompleteQuest() 
    {
        if (!unlockDialogues) return;
        npcGiver.dialogueLines = aknowledgeDialogue;
        completeQuest = true;
        
    }
}
