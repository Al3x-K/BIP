using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeClickToToggleApp : MonoBehaviour
{
    public Canvas social_media_menu;

    void Awake()
    {
        if (social_media_menu != null) {
            Debug.Log("Social Media Menu found and assigned.");
        } else {
            Debug.Log("Social Media Menu not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            CloseMenu();
        }
    }

    public void CloseMenu() {
        social_media_menu.enabled = !social_media_menu.enabled;
    }
}
