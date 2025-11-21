// Assets/_StarterPackage/Core/Commands/ConfigurationCommand.cs
using UnityEngine;
using System.Threading.Tasks;

public class LoadConfigsCommand : MonoBehaviour, ICommand
{
    public string StepName => "Loading Configuration";

    public async Task ExecuteAsync(System.Action<float> progressCallback = null)
    {
        Debug.Log("[Command] " + StepName);

        // Simulate fetching remote config
        for (int i = 0; i <= 10; i++)
        {
            await Task.Delay(50); // Simulate network delay
            progressCallback?.Invoke(i / 10f);
        }

        // TODO: Replace with actual remote config fetch
        // Example:
        // var config = await RemoteConfigService.FetchAsync();
        // GameConfig.Instance.Apply(config);

        Debug.Log("[Command] Configuration fetched");
    }

    public void OnComplete()
    {
        Debug.Log("[Command Completed] " + StepName);
    }
}
