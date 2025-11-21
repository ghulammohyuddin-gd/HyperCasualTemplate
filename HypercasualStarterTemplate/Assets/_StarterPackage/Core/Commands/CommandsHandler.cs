// Assets/_StarterPackage/Core/Commands/CommandHandler.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CommandHandler : MonoBehaviour
{
    [Tooltip("Drag command MonoBehaviours here in order of execution")]
    public List<MonoBehaviour> commandsInInspector;

    private List<ICommand> _commands = new List<ICommand>();

    private void Awake()
    {
        foreach (var mb in commandsInInspector)
        {
            if (mb is ICommand cmd)
                _commands.Add(cmd);
        }
    }

    public async Task RunAllAsync(System.Action<string, float> stepProgressCallback = null)
    {
        foreach (var command in _commands)
        {
            await command.ExecuteAsync(progress =>
            {
                stepProgressCallback?.Invoke(command.StepName, progress);
            });

            command.OnComplete();
        }

        Debug.Log("[CommandHandler] All commands completed.");
    }
}
