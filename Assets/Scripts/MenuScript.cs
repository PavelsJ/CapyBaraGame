using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void OnMenuButton ()
    {
        SceneManager.LoadScene(0);
    }

    public void OnSettingsButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(2);
    }
}
