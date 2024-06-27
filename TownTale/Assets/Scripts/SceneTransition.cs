using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 newPlayerPosition;

    private CapsuleCollider2D capsuleCollider;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the door. Loading scene: " + sceneToLoad);
            GameManager.playerPosition = newPlayerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}