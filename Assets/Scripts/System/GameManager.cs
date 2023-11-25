using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsInsideCave = false;
    public Vector3 caveSpawnPos;

    private void Awake()
    {
        // Ensure that this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Subscribe to the scene loaded event to handle initialization
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Your scene initialization code goes here
        // For example, you might want to check the scene name and set initial conditions

        if (scene.name == "Forrest")
        {
           
            if (IsInsideCave)
            {
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                player.transform.position = caveSpawnPos;
                IsInsideCave = false;
            }
        }
        else if (scene.name == "Cave")
        {
            IsInsideCave = true;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}