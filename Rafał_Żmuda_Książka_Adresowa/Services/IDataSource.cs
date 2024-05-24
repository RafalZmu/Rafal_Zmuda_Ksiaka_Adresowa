using Rafał_Żmuda_Książka_Adresowa.Models;

namespace Rafał_Żmuda_Książka_Adresowa.Services
{
    public interface IDataSource
    {
        List<Address> LoadAdresses();

        void SaveAdresses(List<Address> adresses);
    }
}