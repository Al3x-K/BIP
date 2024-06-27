using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    void Update() {
        bool isActive = creditsPanel.activeSelf;

        if (isActive && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            creditsPanel.SetActive(!isActive);
        }
    }

    public void enableCredits()
    {
        bool isActive = creditsPanel.activeSelf;
        creditsPanel.SetActive(!isActive);
    }
    
    public void startGame()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
