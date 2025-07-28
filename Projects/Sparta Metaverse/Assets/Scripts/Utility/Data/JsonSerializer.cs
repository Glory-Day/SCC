using System.IO;
using UnityEngine;

namespace Backend.Utility.Data
{
    public static class JsonSerializer
    {
        /// <summary>
        /// Reads an external Json file and deserializes it.
        /// </summary>
        /// <param name="path"> External Json file path. </param>
        /// <typeparam name="T"> Serializable Json data type. </typeparam>
        /// <returns> Deserialized data type instances. </returns>
        public static T Deserialize<T>(string path)
        {
            var text = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(text);

            return data;
        }
        
        /// <summary>
        /// Serializes a Json data instance and writes the file to an external path.
        /// </summary>
        /// <param name="path"> External Json file path. </param>
        /// <param name="data"> Data instances to serialize. </param>
        /// <typeparam name="T"> Serializable Json data type. </typeparam>
        public static void Serialize<T>(string path, T data)
        {
            var text = JsonUtility.ToJson(data);
            
            File.WriteAllText(path, text);
        }
    }
}