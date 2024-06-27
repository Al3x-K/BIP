using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, ICollectible
{
    public static event HandleBookCollected OnBookCollected;
    public delegate void HandleBookCollected(ItemData itemData);
    public ItemData BookData;
    public void Collect()
    {
        Destroy(gameObject);
        OnBookCollected?.Invoke(BookData);
    }
}
