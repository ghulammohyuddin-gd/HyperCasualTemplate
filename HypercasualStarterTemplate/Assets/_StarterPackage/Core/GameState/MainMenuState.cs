using UnityEngine;

public class MainMenuState : IGameState
{
    public void OnEnter()
    {
        // Show the Main Menu UI screen
        ScreenManager.Instance.ShowScreen(ScreenType.MainMenu);
        Debug.Log("Entered Main Menu State");
    }

    public void OnExit()
    {
        // Hide the Main Menu screen
        ScreenManager.Instance.HideScreen(ScreenType.MainMenu);
    }
}
