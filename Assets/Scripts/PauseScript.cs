using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public InputActionReference inputPause;
    public GameObject pause;
    private bool isGameFrozen = false;

    void Start()
    {
        pause.SetActive(false);
        isGameFrozen = false;
        Time.timeScale = 1f;
        inputPause.action.started += Pause;
    }

    private void OnDisable()
    {
        inputPause.action.started -= Pause;
    }
    
    private void TogglePause()
    {
        pause.SetActive(!pause.activeSelf);

        if (pause.activeSelf)
        {
            FreezeGame();
        }
        else
        {
            UnfreezeGame();
        }
    }

    public void FreezeGame()
    {
        isGameFrozen = true;
        Time.timeScale = 0f;
    }

    public void UnfreezeGame()
    {
        isGameFrozen = false;
        Time.timeScale = 1f;
    }

    public void UnToggleGameObject()
    {
        pause.SetActive(false);
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        TogglePause();
    }
}
