// Assets/_StarterPackage/Core/Commands/LoadUICommand.cs
using UnityEngine;
using System.Threading.Tasks;

public class LoadUICommand : MonoBehaviour, ICommand
{
    public string StepName => "Loading UI";

    public async Task ExecuteAsync(System.Action<float> progressCallback = null)
    {
        Debug.Log("[Command] " + StepName);

        // Simulate UI loading
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
