using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class LoadingBootstrapper : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;
    [SerializeField] private CommandHandler commandHandler;

    private async void Start()
    {
        // 1️⃣ Show initial
        loadingScreen?.SetProgress("Starting...", 0f);

        // 2️⃣ Run all commands sequentially
        await commandHandler.RunAllAsync((stepName, stepProgress) =>
        {
            // Update loading screen with step name and progress
            // Progress scaled to 0–80% for commands
            loadingScreen?.SetProgress(stepName, stepProgress * 0.8f);
        });

        // 3️⃣ Load MainMenu scene asynchronously (remaining 20%)
        var asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingScreen?.SetProgress("Loading Main Menu", 0.8f + progress * 0.2f);

            if (asyncLoad.progress >= 0.9f)
                asyncLoad.allowSceneActivation = true;

            await Task.Yield();
        }

        // 4️⃣ Set MainMenu state after scene loaded
        GameStateMachine.Instance.SetState(new MainMenuState());
    }
}
