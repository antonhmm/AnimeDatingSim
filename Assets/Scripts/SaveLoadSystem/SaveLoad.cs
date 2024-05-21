using System.IO;
using Newtonsoft.Json;

public static class SaveLoad
{
    public static T Load<T>(string key) where T : new()
    {
        if (File.Exists(key))
        {
            var json = File.ReadAllText(key);
            return JsonConvert.DeserializeObject<T>(json);
        }
        else
        {
            return new T();
        }
    }

    public static void Save<T>(string key, T saveData)
    {
        var json = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(key, json);
    }
}
