using System.Data;

namespace TextRPG.Object.Scene;

public class TablePageRenderer : IRenderable, IPageable
{
    private const int HeaderLength = 3;
    private const int ContentLength = 9;
    
    private readonly List<string> _table;

    private int _index = 2;
    
    public TablePageRenderer(List<string> table)
    {
        _table = table;
        
        while ((_table.Count - HeaderLength) % ContentLength != 0)
        {
            _table.Insert(_table.Count - 1, _table[2]);
        }
    }
    
    public void Render()
    {
        var top = 2;
        var count = ContentLength;
        for (var i = _index; i < _table.Count - 1; i++, top++, count--)
        {
            Screen.Write(_table[i], Screen.Layout.Content + top);

            if (count == 0)
            {
                break;
            }
        }
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
    
    public void ToNextPage()
    {
        if (_index + 9 <= Length)
        {
            _index += 9;
        }
        
        Render();
    }

    public void ToPreviousPage()
    {
        if (_index - 9 >= 2)
        {
            _index -= 9;
        }
        
        Render();
    }

    private int Length => _table.Count - HeaderLength;
    
    public int CurrentPageNumber { get; private set; }
}