using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject volume;
    public GameObject gamepad;
    public GameObject keyboard;

    void Start()
    {
        volume.SetActive(true);
        gamepad.SetActive(false);
        keyboard.SetActive(false);
    }

    public void ToggleVolume()
    {
        volume.SetActive(true);
        gamepad.SetActive(false);
        keyboard.SetActive(false);
    }

    public void ToggleGamePad()
    {
        volume.SetActive(false);
        gamepad.SetActive(true);
        keyboard.SetActive(false);
    }

    public void ToggleKeyBoard()
    {
        volume.SetActive(false);
        gamepad.SetActive(false);
        keyboard.SetActive(true);
    }
}
