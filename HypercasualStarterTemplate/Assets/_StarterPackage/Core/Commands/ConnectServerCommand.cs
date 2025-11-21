// Assets/_StarterPackage/Core/Commands/ConnectServerCommand.cs
using UnityEngine;
using System.Threading.Tasks;

public class ConnectServerCommand : MonoBehaviour, ICommand
{
    public string StepName => "Connecting to Server";

    public async Task ExecuteAsync(System.Action<float> progressCallback = null)
    {
        Debug.Log("[Command] " + StepName);
        // Simulate server connection
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
