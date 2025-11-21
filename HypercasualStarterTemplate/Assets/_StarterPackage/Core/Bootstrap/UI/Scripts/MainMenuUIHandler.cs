using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIHandler : MonoBehaviour
{
    public Button playButton;

    void Awake()
    {
        if (playButton != null)
            playButton.onClick.AddListener(OnPlayClicked);
    }

    void OnPlayClicked()
    {
        // Switch to Gameplay state
        GameStateMachine.Instance.SetState(new GameplayState());
    }
}
