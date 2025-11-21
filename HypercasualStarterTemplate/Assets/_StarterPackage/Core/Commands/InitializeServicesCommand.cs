// Assets/_StarterPackage/Core/Commands/InitializeServicesCommand.cs
using UnityEngine;
using System.Threading.Tasks;

public class InitializeServicesCommand : MonoBehaviour, ICommand
{
    public string StepName => "Initializing Services";

    public async Task ExecuteAsync(System.Action<float> progressCallback = null)
    {
        Debug.Log("[Command] " + StepName);

        // Example: simulate service initialization
        for (int i = 0; i <= 10; i++)
        {
            await Task.Delay(50);
            progressCallback?.Invoke(i / 10f);
        }

        // Optionally initialize your Services singleton here
        if (Services.Instance == null)
        {
            var go = new GameObject("Services");
            go.AddComponent<Services>();
        }

        await Services.Instance.InitializeAsync(progressCallback);
    }

    public void OnComplete()
    {
        Debug.Log("[Command Completed] " + StepName);
    }
}
