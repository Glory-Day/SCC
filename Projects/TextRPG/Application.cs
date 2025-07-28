using TextRPG.Data;
using TextRPG.Object.Scene;
using TextRPG.Utils;
using TextRPG.Utils.Extension;

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

                    //TODO: You must fix this code. You need to set and use the functionality on the Screen object.
                    Screen.Write("            ", Screen.Layout.Input);
                    Screen.Write(">>  ", Screen.Layout.Input);
                    
                    var text = Console.ReadLine();
                    if (text == null)
                    {
                        throw new Exception();
                    }
                    
                    var key = int.Parse(text);
                    
                    if (_sceneManager.Execute(key))
                    {
                        // It's valid scene built-in command key.
                        continue;
                    }
                    
                    if (_sceneManager.IsValidKey(key))
                    {
                        // It's valid scene movement command keys.
                        break;
                    }
                    
                    Screen.Write("잘못된 명령어입니다.", Screen.Layout.Message, ConsoleColor.DarkRed);
                }
            }

            Configuration.Reset();
        }
    }
}