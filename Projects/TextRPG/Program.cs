using System.Data;
using Microsoft.VisualBasic;
using TextRPG.Data;

namespace TextRPG
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var game = new Application();
                game.Play();
            }
            catch (PlatformNotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}