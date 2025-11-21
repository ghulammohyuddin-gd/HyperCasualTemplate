using System.Threading.Tasks;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    public void LogEvent(string eventName, string parameter = null)
        => Debug.Log($"[AnalyticsManager] Event: {eventName}, Param: {parameter}");

    public async Task InitializeAsync()
    {
        Debug.Log("[AnalyticsManager] Initializing Analytics...");
        await Task.Delay(100); // simulate SDK initialization
        Debug.Log("[AnalyticsManager] Analytics Initialized");
    }
}
