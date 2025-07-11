using System.Data;
using TextRPG.Data;

namespace TextRPG.Object.Scene;

public class SaleScene : Scene
{
    private readonly DataTable _table;

    private int _index = 2;
    private int _length;
    
    public SaleScene(SceneData data) : base(data)
    {
        _table = new DataTable();

        Commands[3] = ToNextPage;
        Commands[4] = ToPreviousPage;
    }
    
    public override void Render()
    {
        base.Render();
        
        var playerData = DataManager.Instance.PlayerData;
        var equipmentData = DataManager.Instance.EquipmentData;
        
        Screen.Write($"{Data.Contents[0]}{playerData.Gold.ToString()} ", Screen.Layout.Content - 1);
        
        _table.Columns.Add(Data.Contents[1], typeof(List<string>));
        _table.Columns.Add(Data.Contents[2], typeof(string));
        _table.Columns.Add(Data.Contents[3], typeof(List<string>));
        _table.Columns.Add(Data.Contents[4], typeof(string));
        for (var i = 0; i < equipmentData.Length; i++)
        {
            _table.Rows.Add(
                equipmentData[i].Name.WordWrap(15), 
                $"{Data.Contents[equipmentData[i].Type + 5]}(+{equipmentData[i].Point[equipmentData[i].Type]})",
                equipmentData[i].Description.WordWrap(48),
                playerData.Equipments.Contains(i) ? Data.Contents[7] : equipmentData[i].Price);
        }
        
        var table = _table.ToList(equipmentData.Length);
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