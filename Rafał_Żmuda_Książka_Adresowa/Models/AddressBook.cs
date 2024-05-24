using Rafał_Żmuda_Książka_Adresowa.Services;

namespace Rafał_Żmuda_Książka_Adresowa.Models
{
    public interface IAddressBook
    {
        List<Adress> Addresses { get; set; }

        void AddAddress(Adress adress);
        List<Adress> GetByCity(string city);
        Adress GetLastAddress();
    }

    public class AddressBook : IAddressBook
    {
        public List<Adress> Addresses { get; set; } = [];

        private IDataSource _dataSource;

        public AddressBook(IDataSource dataSource)
        {
            _dataSource = dataSource;
            Addresses = _dataSource.LoadAdresses();
        }

        public void AddAddress(Adress adress)
        {
            Addresses.Add(adress);
            _dataSource.SaveAdresses(Addresses);
        }

        public List<Adress> GetByCity(string city)
        {
            return Addresses.Where(adress => adress.City == city).ToList();
        }
        public Adress GetLastAddress()
        {
            return Addresses.OrderByDescending(Adresses => Adresses.CreationDate).FirstOrDefault() ?? new Adress();
        }
    }
}
