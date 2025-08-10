using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<DialogueQuest> DQuests = new List<DialogueQuest>();
    public List<FetchQuest>   FQuests = new List<FetchQuest>();

    public GameObject WinPopUpPanel;


    void Update()
    {
        if (CheckVictoryCondition())
        {
            WinGame();
        }
    }

    bool CheckVictoryCondition()
    {
        bool victory = true;
       foreach (DialogueQuest quest in DQuests) 
        {
            if (!quest.completeQuest) 
            { 
                victory = false;
            }
        }
       foreach (FetchQuest quest in FQuests) 
        {
            if (!quest.completeQuest) 
            { 
                victory = false;
            }
        }
       return victory;
    }

    void WinGame()
    {
        Debug.Log("yay");
        WinPopUpPanel.SetActive(true);
    }

}
