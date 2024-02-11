using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;
    public InputActionReference dialogueAction;

    [SerializeField] private TextAsset inkJson;
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        
        
        dialogueAction.action.Enable();
    }

    private void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            
            if(dialogueAction.action.triggered)
            {
                StartDialogue();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    
    private void StartDialogue()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJson);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
