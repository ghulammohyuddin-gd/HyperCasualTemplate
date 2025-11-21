using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScreenType
{
    None,
    MainMenu,
    Gameplay
}

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;

    [Header("Screen Prefabs")]
    public GameObject mainMenuScreenPrefab;
    public GameObject gameplayScreenPrefab;

    [Header("UI Root")]
    public Transform screenRoot; // Assigned automatically to Canvas in current scene

    private Dictionary<ScreenType, GameObject> screens = new();
    private ScreenType currentScreen = ScreenType.None;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find Canvas in the new scene and assign as screenRoot
        Canvas canvasInScene = FindObjectOfType<Canvas>();
        if (canvasInScene != null)
        {
            screenRoot = canvasInScene.transform;
            Debug.Log("[ScreenManager] screenRoot set to Canvas in scene: " + scene.name);
        }
        else
        {
            Debug.LogWarning("[ScreenManager] No Canvas found in scene: " + scene.name);
        }

        // Optional: hide all screens from previous scene
        HideCurrentScreen();
    }

    public void ShowScreen(ScreenType type)
    {
        if (screenRoot == null)
        {
            Debug.LogError("[ScreenManager] screenRoot is null. Cannot show screen: " + type);
            return;
        }

        HideCurrentScreen();

        GameObject screen;

        // Use existing instance if already created
        if (screens.ContainsKey(type) && screens[type] != null)
        {
            screen = screens[type];
        }
        else
        {
            GameObject prefab = GetPrefab(type);
            if (prefab == null)
            {
                Debug.LogError("[ScreenManager] Screen prefab missing for: " + type);
                return;
            }

            screen = Instantiate(prefab, screenRoot);
            screens[type] = screen;
        }

        screen.SetActive(true);
        currentScreen = type;
    }

    public void HideCurrentScreen(bool destroy = false)
    {
        if (currentScreen != ScreenType.None)
        {
            HideScreen(currentScreen, destroy);
            currentScreen = ScreenType.None;
        }
    }

    public void HideScreen(ScreenType type, bool destroy = false)
    {
        if (screens.ContainsKey(type) && screens[type] != null)
        {
            if (destroy)
            {
                Destroy(screens[type]);
                screens.Remove(type);
            }
            else
            {
                screens[type].SetActive(false);
            }
        }
    }

    private GameObject GetPrefab(ScreenType type)
    {
        return type switch
        {
            ScreenType.MainMenu => mainMenuScreenPrefab,
            ScreenType.Gameplay => gameplayScreenPrefab,
            _ => null
        };
    }

    /// <summary>
    /// Optional: manually set screenRoot from any script
    /// </summary>
    public void SetScreenRoot(Transform root)
    {
        screenRoot = root;
    }
}
