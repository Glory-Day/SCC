using TextRPG.Utils.Extension;

namespace TextRPG.Object.Scene;

public class PageCommand : Command
{
    public override void Execute(int index)
    {
        if (index == ConsoleKey.LeftArrow.ToInt())
        {
            _callbacks[0].Invoke();
        }
        else if (index == ConsoleKey.RightArrow.ToInt())
        {
            _callbacks[1].Invoke();
        }
        else
        {
            base.Execute(index);
        }
    }
}