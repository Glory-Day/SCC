using System.Text;

namespace TextRPG
{
    public static class Configuration
    {
        private static ConsoleProperty _applicationProperty;
        private static ConsoleProperty _originalProperty;

        /// <summary>
        /// Set from the original console configuration to the application console configuration.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException"></exception>
        public static void SetUp()
        {
            if (OperatingSystem.IsWindows())
            {
                _applicationProperty = new ConsoleProperty("Rtan RPG", 1280, 720, Encoding.UTF8, false);
                _originalProperty = new ConsoleProperty(Console.Title, Console.WindowWidth, Console.WindowHeight, Console.OutputEncoding, Console.CursorVisible);

                Console.Title = _applicationProperty.Title;
                Console.CursorVisible = _applicationProperty.IsCursorVisible;

                Console.SetWindowSize(_applicationProperty.Width, _applicationProperty.Height);
                
                Console.OutputEncoding = _applicationProperty.Encoding;
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        /// <summary>
        /// Reset to the original console configuration.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException"></exception>
        public static void Reset()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Title = _originalProperty.Title;
                Console.CursorVisible = _originalProperty.IsCursorVisible;

                Console.SetWindowSize(_originalProperty.Width, _originalProperty.Height);
                
                Console.OutputEncoding = _originalProperty.Encoding;
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        #region STRUCTURE API

        private struct ConsoleProperty
        {
            public ConsoleProperty(string title, int width, int height, Encoding encoding, bool isCursorVisible)
            {
                Title = title;
                Width = width;
                Height = height;
                Encoding = encoding;
                IsCursorVisible = isCursorVisible;
            }

            public string Title { get; private set; }

            public int Width { get; private set; }
            public int Height { get; private set; }
            
            public Encoding Encoding { get; private set; } 

            public bool IsCursorVisible { get; private set; }
        }

        #endregion
    }
}