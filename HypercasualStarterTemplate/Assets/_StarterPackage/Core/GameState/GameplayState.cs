using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameplayState : IGameState
{
    public async void OnEnter()
    {
        Debug.Log("[GameplayState] Enter");

        // Load Gameplay scene asynchronously
        await SceneManager.LoadSceneAsync("Gameplay");

        // Optionally, set up screenRoot for ScreenManager
        Canvas canvas = Object.FindObjectOfType<Canvas>();
        if (canvas != null)
            ScreenManager.Instance.SetScreenRoot(canvas.transform);

        // Show gameplay UI
        ScreenManager.Instance.ShowScreen(ScreenType.Gameplay);
    }

    public void OnExit()
    {
        Debug.Log("[GameplayState] Exit");
    }
}
