using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SocialMediaApp : MonoBehaviour
{
    public GameObject appPanel;
    public GameObject player;
    public PlayerController playerMovement;

    void Start() {
        playerMovement = player.GetComponent<PlayerController>();
    }

    void Update() {
        bool isActive = appPanel.activeSelf;

        if (Input.GetKeyDown(KeyCode.Q) || (isActive && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))))
        {
            toggleApp();
        }
    }

    public void toggleApp()
    {
        bool isActive = appPanel.activeSelf;
        appPanel.SetActive(!isActive);
        if (!isActive) {playerMovement.moveSpeed = 0f;}
        else {playerMovement.moveSpeed = 5f;}
    }

    public void addArrowTracker()
    {
        
    }
}