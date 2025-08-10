using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchQuest : MonoBehaviour
{
    public NPCDialogue npcGiver;
    public ItemPickUp QuestPlayerReciever;
    public Items QuestItem;

    public string[] questDialogue;
    public string[] aknowledgeDialogue;

    public bool unlockItem = false;
    public bool completeQuest= false;

    private void Start()
    {
        QuestItem.gameObject.SetActive(false);
        npcGiver.dialogueLines = questDialogue;
        npcGiver.OnCompleteDialogue += UnlockText;
        QuestPlayerReciever.OnPickUp += FetchQuestComplete;
    }

    public void UnlockText() 
    {
        if (completeQuest)
        { 
          this.gameObject.SetActive(false);
        }
        else
        {
            QuestItem.gameObject.SetActive(true);
        }
    }


    public void FetchQuestComplete()
    {
        npcGiver.dialogueLines = aknowledgeDialogue;
        completeQuest = true;
    }
}
