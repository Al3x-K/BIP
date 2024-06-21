using UnityEngine;
using TMPro; // Ensure TextMeshPro namespace is included
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public Button button; // This should be a reference to the Button component

    void Start()
    {
        // Ensure the button is assigned in the Inspector
        if (button == null)
        {
            Debug.LogError("Button component reference is missing. Please assign the Button component in the Inspector.", this);
            return;
        }

        // Listener should be added in the Inspector, so this code can be removed:
        // button.onClick.AddListener(OnClick); 
    }

    // This method will be linked to the Button's OnClick event in the Inspector
    public void OnClick()
    {
        // Use TextMeshProUGUI for TMP text component
        TextMeshProUGUI buttonTextTMP = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonTextTMP != null)
        {
            Debug.Log("Button clicked: " + buttonTextTMP.text);
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component found in children of this Button.");
        }
    }
}
