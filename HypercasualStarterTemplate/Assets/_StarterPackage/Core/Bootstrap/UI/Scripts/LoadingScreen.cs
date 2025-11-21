using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI stepText;
    [SerializeField] private TextMeshProUGUI percentageText;

    // ✅ Updated method: takes step name and progress 0–1
    public void SetProgress(string step, float progress)
    {
        if (progressBar != null)
            progressBar.value = progress;

        if (stepText != null)
            stepText.text = step;

        if (percentageText != null)
            percentageText.text = $"{Mathf.RoundToInt(progress * 100)}%";
    }
}
