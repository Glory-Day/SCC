using System.Text.Json;

namespace TextRPG
{
    public static class JsonDataSerializer
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions() { WriteIndented = true };
        
        public static T? Deserialize<T>(string path)
        {
            var data = default(T);
            
            try
            {
                var text = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<T>(text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            return data;
        }

        public static void Serialize<T>(string path, T data)
        {
            try
            {
                var text = JsonSerializer.Serialize(data, Options);
                
                File.WriteAllText(path, text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        
    }
}