using Microsoft.AspNetCore.Http.HttpResults;
using Rafał_Żmuda_Książka_Adresowa.Services;

namespace Rafał_Żmuda_Książka_Adresowa.Models
{
    public interface IAddressBook
    {
        List<Address> Addresses { get; set; }

        int AddAddress(Address adress);
        List<Address> GetByCity(string city);
        Address GetLastAddress();
        void SaveAdresses();
    }

    public class AddressBook : IAddressBook
    {
        public List<Address> Addresses { get; set; } = [];

        private IDataSource _dataSource;

        public AddressBook(IDataSource dataSource)
        {
            _dataSource = dataSource;
            Addresses = _dataSource.LoadAdresses();
        }

        public int AddAddress(Address address)
        {
            var validator = new AddressValidator();
            var result = validator.Validate(address);
            if (result.IsValid == false)
            {
                return 1;
            }

            try
            {
                address.CreationDate = DateTime.Now;
                Addresses.Add(address);
                _dataSource.SaveAdresses(Addresses);
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public List<Address> GetByCity(string city)
        {
            return Addresses.Where(adress => adress.City == city).ToList();
        }

        public Address GetLastAddress()
        {
            return Addresses.OrderByDescending(Adresses => Adresses.CreationDate).FirstOrDefault();
        }

        public void SaveAdresses()
        {
            _dataSource.SaveAdresses(Addresses);
        }
    }
}
