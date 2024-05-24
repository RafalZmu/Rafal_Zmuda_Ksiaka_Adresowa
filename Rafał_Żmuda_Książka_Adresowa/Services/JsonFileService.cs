using Rafał_Żmuda_Książka_Adresowa.Models;
using System.Text.Json;

namespace Rafał_Żmuda_Książka_Adresowa.Services
{
    public class JsonFileService : IDataSource
    {
        private readonly string _jsonFilePath;

        public JsonFileService()
        {
            _jsonFilePath = Directory.GetCurrentDirectory() + "/AddressBook.json";
            if (File.Exists(_jsonFilePath) == false)
            {
                File.Create(_jsonFilePath).Close();
                File.WriteAllText(_jsonFilePath, "[]");
            }
        }

        public void SaveAdresses(List<Adress> adresses)
        {
            string jsonString = JsonSerializer.Serialize(adresses);
            File.WriteAllText(_jsonFilePath, jsonString);
        }

        public List<Adress> LoadAdresses()
        {
            string jsonString = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<Adress>>(jsonString) ?? [];
        }
    }
}
