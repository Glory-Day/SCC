using System.IO;
using Backend.Data;
using Backend.Utility.Data;
using UnityEngine;

namespace Utility
{
    public class DataManager : Singleton<DataManager>
    {
        private static string GetPersistentDataPath(string filename)
        {
            return $"{Path.Combine(Application.persistentDataPath, filename)}.json";
        }
        
        protected override void Initialize()
        {
            base.Initialize();

            Load();
        }

        public void Load()
        {
            if (File.Exists(GetPersistentDataPath(nameof(StageData))) == false)
            {
                var data = new [] { new StageData(), new StageData() };
                JsonSerializer.Serialize(GetPersistentDataPath(nameof(StageData)), new StageData());
            }
            
            StageData = JsonSerializer.Deserialize<StageData[]>(GetPersistentDataPath(nameof(StageData)));
        }

        public void Save()
        {
            JsonSerializer.Serialize(GetPersistentDataPath(nameof(StageData)), StageData);
        }

        public StageData[] StageData { get; set; }
    }
}