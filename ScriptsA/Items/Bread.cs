using UnityEngine;

public class Bread : MonoBehaviour, ICollectible
{
    public static event HandleBreadCollected OnBreadCollected;
    public delegate void HandleBreadCollected(ItemData itemData);
    public ItemData BreadData;


    public void Collect()
    {
        Destroy(gameObject);
        OnBreadCollected?.Invoke(BreadData);
    }
}