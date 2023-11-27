using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool IsInsideCave = false;
    public Vector3 caveSpawnPos;
    public Vector3 insideCaveSpawnPos;

    private void Awake()
    {
        if (instance != null)
        {
            // Ensure that this GameObject persists across scenes
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


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
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.transform.position = insideCaveSpawnPos;
            IsInsideCave = true;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}