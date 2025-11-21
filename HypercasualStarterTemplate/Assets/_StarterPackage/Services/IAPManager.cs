using System.Threading.Tasks;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    public void Purchase(string productId)
        => Debug.Log($"[IAPManager] Purchasing {productId}");

    public async Task InitializeAsync()
    {
        Debug.Log("[IAPManager] Initializing IAP...");
        await Task.Delay(100); // simulate SDK initialization
        Debug.Log("[IAPManager] IAP Initialized");
    }
}
