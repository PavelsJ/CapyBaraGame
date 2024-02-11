using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialog : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Animator anim;
    public string[] dialogue;
    private int index;

    public GameObject continueButoon;
    public float wordSpeed;
    public bool playerIsClose;
    
    void Start()
    {
        dialoguePanel.SetActive(true);
        continueButoon.SetActive(false);
        StartCoroutine(Typing());
    }

    private void Update()
    {
        if (dialogueText.text == dialogue[index])
        {
            continueButoon.SetActive(true);
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
        dialogueText.text = "";
        
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
            dialogueText.text = "";
            StartCoroutine((Typing()));
        }
        else
        {
            ZeroText();
            anim.SetTrigger("End");
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3); 
    }

    
}
