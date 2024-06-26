using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector3 playerPosition = Vector3.zero;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
