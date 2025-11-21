using System.Threading.Tasks;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    // Old methods can remain
    public void ShowInterstitial() => Debug.Log("[AdsManager] Show interstitial");
    public void ShowRewarded() => Debug.Log("[AdsManager] Show rewarded");

    // New async initializer
    public async Task InitializeAsync()
    {
        Debug.Log("[AdsManager] Initializing Ads...");
        await Task.Delay(100); // simulate SDK initialization
        Debug.Log("[AdsManager] Ads Initialized");
    }
}
