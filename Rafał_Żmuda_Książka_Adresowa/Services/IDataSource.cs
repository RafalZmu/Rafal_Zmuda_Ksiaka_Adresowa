using Rafał_Żmuda_Książka_Adresowa.Models;

namespace Rafał_Żmuda_Książka_Adresowa.Services
{
    public interface IDataSource
    {
        List<Adress> LoadAdresses();
        void SaveAdresses(List<Adress> adresses);
    }
}