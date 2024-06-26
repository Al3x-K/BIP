using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    public Transform playerTransform; // Reference to the player's Transform

    private void OnEnable()
    {
        Flower.OnFlowerCollected += Add;
        Bread.OnBreadCollected += Add;
        Book.OnBookCollected += Add;
    }
    private void OnDisable()
    {
        Flower.OnFlowerCollected -= Add;
        Bread.OnBreadCollected -= Add;
        Book.OnBookCollected -= Add;
    }
    public void Add(ItemData itemdata)
    {
        if (itemDictionary.TryGetValue(itemdata, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemdata);
            inventory.Add(newItem);
            itemDictionary.Add(itemdata, newItem);
            OnInventoryChange?.Invoke(inventory);
        }


    }

    public void Remove(ItemData itemdata)
    {
        if (itemDictionary.TryGetValue(itemdata, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.StackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemdata);
            }
        }
        OnInventoryChange?.Invoke(inventory);
    }

    public void Drop(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            // Calculate drop position at a greater distance away from the player
            float dropDistance = 1.0f; // Adjust this value as needed (greater distance)
            Vector2 dropDirection = playerTransform.up; // Example: drop to the right of the player
            Vector2 dropPosition = (Vector2)playerTransform.position + dropDirection * dropDistance;

            // Instantiate the item prefab at the calculated drop position
            GameObject droppedItem = Instantiate(itemData.prefab, dropPosition, Quaternion.identity);

            Debug.Log($"Dropped item {itemData.displayName} at position: {dropPosition}");

            // Remove the item from the inventory
            Remove(itemData);
        }
        else
        {
            Debug.LogError($"Item {itemData.displayName} not found in inventory");
        }
    }




}
