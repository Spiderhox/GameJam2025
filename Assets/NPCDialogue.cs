using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class NPCDialogue : MonoBehaviour
{
    public GameObject Dialogo;
    public TMPro.TextMeshProUGUI dialogueText;
    [TextArea(5, 10)]
    public string[] dialogueLines;

    private int currentLine = 0;
    public event Action OnCompleteDialogue;

    public void StartDialogue()
    {
        Dialogo.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
    }

    public void ContinueDialogue()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        if (Dialogo != null)
        {
            Dialogo.SetActive(false);
        }
        
        if (currentLine >= dialogueLines.Length) 
        {
            OnCompleteDialogue?.Invoke();
        }
        currentLine = 0;
    }

}
