using System.Collections.Generic;
using System.Threading.Tasks;
public static class CommandRunner
{
    public static async Task RunAsync(ICommand command) => await command.ExecuteAsync();
    public static async Task RunSequenceAsync(IEnumerable<ICommand> cmds)
    {
        foreach (var c in cmds) await c.ExecuteAsync();
    }
}
