using System.Text;

namespace TextRPG
{
    public static class StringExtensions
    {
        private static readonly char[] Whitespace = { ' ', '\n' };
        
        public static List<string> WordWrap(this string text, int width)
        {
            var list = new List<string>();

            var currentIndex = 0;
            var previousIndex = 0;
            var length = text.Length;
            do
            {
                var sum = 0;
                var count = 0;
                
                for (var i = previousIndex; i < length; i++)
                {
                    sum += text[i].GetGraphicLength();

                    if (sum > width)
                    {
                        break;
                    }
                    
                    count++;
                }
                
                var index = text.LastIndexOfAny(Whitespace, Math.Min(length - 1, previousIndex + count)) + 1;
                currentIndex = previousIndex + count > length ? length : index;
                
                if (currentIndex <= previousIndex)
                {
                    currentIndex = Math.Min(previousIndex + count, length);
                }
                
                list.Add(text.Substring(previousIndex, currentIndex - previousIndex).Trim(Whitespace));
                
                previousIndex = currentIndex;
            }
            while (currentIndex < length);

            return list;
        }
        
        public static int GetGraphicLength(this string text)
        {
            return text.Sum(ch => ch.GetGraphicLength());
        }

        public static int GetUnicodeLength(this string text)
        {
            return text.Sum(ch => ch.GetUnicodeLength());
        }
    }
}