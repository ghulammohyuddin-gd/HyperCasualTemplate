using UnityEngine;
using System.Threading.Tasks;

public class LevelManager
{
    public static LevelManager Instance { get; } = new LevelManager();

    public async Task LoadLevelAsync(int levelIndex = 0)
    {
        // Placeholder: you can use Addressables or SceneManager here
        Debug.Log($"Level {levelIndex} loaded (placeholder)");
        await Task.CompletedTask;
    }
}
