using System.Data;
using TextRPG.Data;

namespace TextRPG.Object.Scene;

public class StatusScene : Scene
{
    private readonly DataTable _table;
    
    public StatusScene(SceneData data) : base(data)
    {
        _table = new DataTable();
    }

    public override void Render()
    {
        base.Render();
        
        var data = DataManager.Instance.PlayerData;
        _table.Columns.Add(Data.Contents[0], typeof(string));
        _table.Columns.Add(data.Level.ToString(), typeof(string));
        _table.Rows.Add(Data.Contents[1], $"{data.Name}({GetClassName(data.Class)})");
        _table.Rows.Add(Data.Contents[2], data.AttackPoint);
        _table.Rows.Add(Data.Contents[3], data.DefensePoint);
        _table.Rows.Add(Data.Contents[4], data.Health);
        _table.Rows.Add(Data.Contents[5], data.Gold);
        
        var table = _table.ToList(8);
        for (var i = 0; i < table.Count; i++)
        {
            Screen.Write(table[i], Screen.Layout.Content + i);
        }
        
        _table.Columns.Clear();
        _table.Rows.Clear();
    }

    private static string GetClassName(int index)
    {
        switch (index)
        {
            case 0:  return "전사";
            case 1:  return "마법사";
            case 2:  return "궁수";
            case 3:  return "도적";
            default: throw new ArgumentOutOfRangeException();
        }
    }
}