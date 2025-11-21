// Assets/_StarterPackage/Core/Commands/LoadAnalyticsCommand.cs
using UnityEngine;
using System.Threading.Tasks;

public class LoadAnalyticsCommand : MonoBehaviour, ICommand
{
    public string StepName => "Loading Analytics";

    public async Task ExecuteAsync(System.Action<float> progressCallback = null)
    {
        Debug.Log("[Command] " + StepName);

        // Simulate loading analytics
        for (int i = 0; i <= 10; i++)
        {
            await Task.Delay(50);
            progressCallback?.Invoke(i / 10f);
        }
    }

    public void OnComplete()
    {
        Debug.Log("[Command Completed] " + StepName);
    }
}
