using TextRPG.Data;
using TextRPG.Object.Scene;

namespace TextRPG;

public class SceneManager
{
    private readonly Scene[] _scenes;

    private Scene? _currentScene;
    
    public SceneManager()
    {
        var data = DataManager.Instance.SceneData;
        if (data == null)
        {
            throw new NullReferenceException();
        }
        
        _scenes = new Scene[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            _scenes[i] = SceneFactory.Create(i, data[i]);
        }

        for (var i = 0; i < data.Length; i++)
        {
            for (var j = 0; j < data[i].Indexes.Length; j++)
            {
                _scenes[i].Iterators[j] = _scenes[data[i].Indexes[j]];
            }
        }
    }

    public void Load(int index)
    {
        if (_currentScene is null)
        {
            _currentScene = _scenes[index];
            _currentScene.Render();

            return;
        }
        
        _currentScene.Reset();

        if (_currentScene.Iterators[index] is Scene nextScene)
        {
            _currentScene = nextScene;
        }
        
        _currentScene.Render();
    }

    public void Execute(int key)
    {
        _currentScene?.Commands[key]?.Invoke();
    }
    
    public bool IsValidKey(int key)
    {
        return _currentScene?.IsValidKey(key) ?? false;
    }
    
    public bool IsValidIndex(int index)
    {
        return _currentScene?.IsValidIndex(index) ?? false;
    }
}