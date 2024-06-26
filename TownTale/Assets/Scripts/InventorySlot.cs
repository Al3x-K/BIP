using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    public Button dropButton; // Add this line

    private void Awake()
    {
        dropButton.onClick.AddListener(OnDropButtonClicked);
    }

    public void ClearSlot()
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
        dropButton.gameObject.SetActive(false); // Hide drop button
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        stackSizeText.enabled = true;
        dropButton.gameObject.SetActive(true); // Show drop button

        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.StackSize.ToString();

        // Store reference to item data for drop button
        currentItemData = item.itemData;
    }

    private ItemData currentItemData;

    private void OnDropButtonClicked()
    {
        // Inform InventoryManager to drop the item
        InventoryManager.Instance.DropItem(currentItemData);
    }

}
