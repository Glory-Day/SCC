using TextRPG.Data;
using TextRPG.Object.Scene;
using TextRPG.Utils;

namespace TextRPG
{
    public class Application
    {
        private readonly SceneManager _sceneManager;
        
        private int _index;
        
        public Application()
        {
            _sceneManager = new SceneManager();
        }

        public void Play()
        {
            Configuration.SetUp();
            
            while (true)
            {
                Console.Clear();
                Screen.DrawBorderLine();
                Screen.Write("원하시는 행동을 입력해주세요. ", Screen.Layout.Request);
                Screen.Write(">>  ", Screen.Layout.Input);

                _sceneManager.Load(_index);
                
                while (true)
                {
                    Screen.ResetCursorPosition();

                    Screen.Write("            ", Screen.Layout.Input);
                    Screen.Write(">>  ", Screen.Layout.Input);

                    if (int.TryParse(Console.ReadLine(), out var key) == false)
                    {
                        continue;
                    }

                    _index = key;

                    if (_sceneManager.IsValidKey(_index))
                    {
                        _sceneManager.Execute(_index);

                        continue;
                    }
                    
                    if (_sceneManager.IsValidIndex(_index))
                    {
                        break;
                    }
                }
            }

            Configuration.Reset();
        }
    }
}