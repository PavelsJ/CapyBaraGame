using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IntroDialogScript : MonoBehaviour
{
    public InputActionReference dialogueAction;

    [SerializeField] private TextAsset inkJson;
    public IEnumerator Start()
    {
        dialogueAction.action.Enable();
        yield return new WaitForSeconds(1f);
        StartDialogue();    
    }
    private void Update()
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if(dialogueAction.action.triggered)
            {
                StartDialogue();
            }
        }
    }
    
    private void StartDialogue()
    {
        DialogueManager.GetInstance().changeScene = true;
        DialogueManager.GetInstance().EnterDialogueMode(inkJson);
    }
    
    private void OnDialogueFinished()
    {
        // Load the next scene when the dialogue is finished
        SceneManager.LoadScene("NextSceneName");
    }
    
}
