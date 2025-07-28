namespace TextRPG.Object.Scene;

public class Command : ICommandable
{
    public Command(int start, int end)
    {
        Callbacks = new Dictionary<int, Action?>();
        for (var i = end - start + 1; i < end; i++)
        {
            Callbacks.Add(i, null);
        }
    }
    
    public virtual void Execute(int index)
    {
        Callbacks[index]?.Invoke();
    }
    
    public Dictionary<int, Action?> Callbacks { get; private set; }
}