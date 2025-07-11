using TextRPG.Data;

namespace TextRPG.Object.Scene
{
    public abstract class Scene : Iterable, IRenderable
    {
        protected readonly SceneData Data;
        
        protected Scene(SceneData data)
        {
            Data = data;

            Iterators = new Iterable[data.Indexes.Length];

            Commands = new Dictionary<int, Action?>();
            for (var i = data.Menus.Length - data.Indexes.Length + 1; data.Menus.Length < i; i++)
            {
                Commands.Add(i, null);
            }
        }

        public Iterable GetNextIterator(int index) => Iterators[index];

        public virtual void Render()
        {
            Screen.Write(Data.Title, Screen.Layout.Title, ConsoleColor.Green);
            Screen.Write(Data.Description, Screen.Layout.Description);
            
            var length = Data.Menus.Length;
            if (Data.HasExit)
            {
                for (var i = 1; i < length; i++)
                {
                    Screen.Write($"{i}. {Data.Menus[i]}", Screen.Layout.Menu + i - 1);
                }
                Screen.Write($"{0}. {Data.Menus[0]}", Screen.Layout.Menu + length - 1);
            }
            else
            {
                for (var i = 0; i < length; i++)
                {
                    Screen.Write($"{i}. {Data.Menus[i]}", Screen.Layout.Menu + i);
                }
            }
        }

        public virtual void Reset() { }

        public bool IsValidKey(int index)
        {
            return Commands.ContainsKey(index);
        }
        
        public bool IsValidIndex(int index)
        {
            return 0 <= index && index < Data.Indexes.Length;
        }
        
        public Iterable[] Iterators { get; }

        public Dictionary<int, Action?> Commands { get; }
    }
}