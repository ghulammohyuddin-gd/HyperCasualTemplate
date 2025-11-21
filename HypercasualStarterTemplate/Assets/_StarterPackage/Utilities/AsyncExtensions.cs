using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public static class AsyncExtensions
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        return AwaitAsyncOperation(asyncOp).GetAwaiter();
    }

    private static async Task AwaitAsyncOperation(AsyncOperation op)
    {
        var tcs = new TaskCompletionSource<bool>();

        op.completed += _ => tcs.SetResult(true);

        await tcs.Task;
    }
}
