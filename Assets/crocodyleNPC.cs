using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class crocodyleNPC : MonoBehaviour
{
    public InputActionReference dialogueAction;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject continueButoon;
    public GameObject notification;
    public float wordSpeed;
    public bool playerIsClose;
    
    void Start()
    {
        notification.SetActive(false);
        dialoguePanel.SetActive(false);
        dialogueAction.action.performed += _ => OnDialogueAction();
        dialogueAction.action.Enable();
    }

    private void Update()
    {
        if (dialogueText.text == dialogue[index])
        {
            continueButoon.SetActive(true);
        }
    }

    private void OnDialogueAction()
    {
        if (dialoguePanel.activeSelf)
        {
            ZeroText();
        }
        else if (playerIsClose)
        {
            notification.SetActive(false);
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }
    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        continueButoon.SetActive(false);
        
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continueButoon.SetActive(false);
        
        if (index < dialogue.Length - 1)
        {
            index++;
            StopCoroutine("Typing");
            dialogueText.text = "";
            StartCoroutine((Typing()));
        }
        else
        {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            notification.SetActive(true);
            playerIsClose = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            notification.SetActive(false);
            playerIsClose = false;
        }
    }
    
    
}
