using UnityEngine;

public class FastTravelUIManager : MonoBehaviour
{
    public GameObject FastTravel;  // Reference to the fast travel panel
    public KeyCode toggleKey = KeyCode.F;  // Key to toggle the fast travel panel

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleFastTravel();
        }
    }

    void ToggleFastTravel()
    {
        bool isActive = FastTravel.activeSelf;
        FastTravel.SetActive(!isActive);
    }
}
