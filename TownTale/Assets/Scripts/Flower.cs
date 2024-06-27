using UnityEngine;

public class Flower : MonoBehaviour, ICollectible
{
    public static event HandleFlowerCollected OnFlowerCollected;
    public delegate void HandleFlowerCollected(ItemData itemData);
    public ItemData flowerData;


    public void Collect()
    {
        Destroy(gameObject);
        OnFlowerCollected?.Invoke(flowerData);  
    }
}