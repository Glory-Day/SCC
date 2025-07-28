namespace TextRPG.Utils.Extension;

public static class ConsoleKeyExtension
{
    public static int ToInt(this ConsoleKey key)
    {
        return Convert.ToInt32(key);
    }
}