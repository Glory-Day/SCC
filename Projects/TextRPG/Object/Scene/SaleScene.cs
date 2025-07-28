using System.Data;
using TextRPG.Data;
using TextRPG.Utils.Extension;

namespace TextRPG.Object.Scene;

public class SaleScene : Scene
{
    private readonly DataTable _table;

    private int _index = 2;
    private int _length;
    
    public SaleScene(SceneData data) : base(data)
    {
        _table = new DataTable();

        Command = new PageCommand();
        Command.Callbacks.Add(ConsoleKey.RightArrow.ToInt(), ToNextPage);
        Command.Callbacks.Add(ConsoleKey.LeftArrow.ToInt(), ToPreviousPage);
    }
    
    public override void Render()
    {
        base.Render();
        
        var playerData = DataManager.Instance.PlayerData;
        var equipmentData = DataManager.Instance.EquipmentData;
        
        Screen.Write($"{Data.Contents[0]}{playerData.Gold.ToString()} ", Screen.Layout.Content - 1);
        
        _table.Columns.Add(Data.Contents[1], typeof(string));
        _table.Columns.Add(Data.Contents[2], typeof(string));
        _table.Columns.Add(Data.Contents[3], typeof(List<string>));
        _table.Columns.Add(Data.Contents[4], typeof(string));
        for (var i = 0; i < playerData.Inventories.Count; i++)
        {
            var index = playerData.Inventories[i];
            _table.Rows.Add(
                equipmentData[index].Name, 
                $"{Data.Contents[equipmentData[index].Type + 5]}(+{equipmentData[index].Point[equipmentData[index].Type]})",
                equipmentData[index].Description.WordWrap(48),
                (int)(equipmentData[i].Price * 0.85f));
        }
        
        var table = _table.ToList(equipmentData.Length, true);
        while ((table.Count - 3) % 9 != 0)
        {
            table.Insert(table.Count - 1, table[2]);
        }
        
        Screen.Write(table[0], Screen.Layout.Content);
        Screen.Write(table[1], Screen.Layout.Content + 1);

        var j = 2;
        var count = 9;
        for (var i = _index; i < table.Count - 1; i++, j++, count--)
        {
            Screen.Write(table[i], Screen.Layout.Content + j);

            if (count == 0)
            {
                break;
            }
        }
        
        Screen.Write(table[^1], Screen.Layout.Content + 11);

        _length = table.Count - 3;
        
        _table.Rows.Clear();
        _table.Columns.Clear();
    }

    public override void Reset()
    {
        base.Reset();

        _index = 2;
        _length = 0;
    }
    
    private void ToNextPage()
    {
        if (_index + 9 <= _length)
        {
            _index += 9;
        }
        
        Render();
    }

    private void ToPreviousPage()
    {
        if (_index - 9 >= 2)
        {
            _index -= 9;
        }
        
        Render();
    }
}