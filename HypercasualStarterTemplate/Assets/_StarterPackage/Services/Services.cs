using UnityEngine;
using System.Threading.Tasks;

public class Services : MonoBehaviour
{
    public static Services Instance { get; private set; }

    public AdsManager Ads { get; private set; }
    public AnalyticsManager Analytics { get; private set; }
    public IAPManager IAP { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Ads = gameObject.AddComponent<AdsManager>();
            Analytics = gameObject.AddComponent<AnalyticsManager>();
            IAP = gameObject.AddComponent<IAPManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async Task InitializeAsync(System.Action<float> onProgress = null)
    {
        float progress = 0f;

        await Ads.InitializeAsync();
        progress += 0.33f;
        onProgress?.Invoke(progress);

        await Analytics.InitializeAsync();
        progress += 0.33f;
        onProgress?.Invoke(progress);

        await IAP.InitializeAsync();
        progress += 0.34f;
        onProgress?.Invoke(progress);

        Debug.Log("[Services] All services initialized.");
    }
}
