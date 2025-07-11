namespace TextRPG
{
    public static class CharExtension
    {
        public static int GetGraphicLength(this char ch)
        {
            return (0xFF00 & ch) == 0 ? 1 : 2;
        }

        public static int GetUnicodeLength(this char ch)
        {
            return (0xFF00 & ch) == 0 ? 0 : 1;
        }
    }
};