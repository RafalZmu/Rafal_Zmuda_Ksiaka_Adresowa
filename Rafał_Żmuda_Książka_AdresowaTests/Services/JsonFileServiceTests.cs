using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rafał_Żmuda_Książka_Adresowa.Models;
using Rafał_Żmuda_Książka_Adresowa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafał_Żmuda_Książka_Adresowa.Services.Tests
{
    [TestClass()]
    public class JsonFileServiceTests
    {
        private IAddressBook _addressBook;

        [TestInitialize]
        public void Initialize()
        {
            _addressBook = new AddressBook(new JsonFileService());
        }

        [TestMethod()]
        public void AddAdressesTest()
        {
            // Arrange
            var addresses = new List<Address>
            {
                new Address
                {
                    Name = "John",
                    SecondName = "Doe",
                    City = "Warsaw",
                    CreationDate = DateTime.Now,
                    Country = "Poland",
                    Email = "example@email.com",
                    PostalCode = "00-001"
                },
                new Address
                {
                    Street = "Marszałkowska",
                    Name = "John",
                    SecondName = "Doe",
                    Number = "2",
                    City = null,
                    Country = "Poland",
                    Email = "example@email.com",
                    PostalCode = "00-001",
                }
            };

            // Act
            var resultAddress1 = _addressBook.AddAddress(addresses[0]);
            var resultAddress2 = _addressBook.AddAddress(addresses[1]);

            //Cleanup
            _addressBook.Addresses.Clear();
            _addressBook.SaveAdresses();

            // Assert
            Assert.AreEqual(0, resultAddress1);
            Assert.AreEqual(1, resultAddress2);

        }

        [TestMethod()]
        public void GetByCityTest()
        {
            // Arrange
            var addresses = new List<Address>
            {
                new Address
                {
                    Name = "John",
                    SecondName = "Doe",
                    City = "Warsaw",
                    Country = "Poland",
                    Email = "example@email.com",
                    PostalCode = "00-001",
                }
            };

            // Act
            _addressBook.AddAddress(addresses[0]);
            var result = _addressBook.GetByCity("Warsaw");

            var resultEmpty = _addressBook.GetByCity("Krakow");

            // Cleanup
            _addressBook.Addresses.Clear();
            _addressBook.SaveAdresses();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.All(address => address.City == "Warsaw"));

            Assert.AreEqual(0, resultEmpty.Count);
            CollectionAssert.AreEqual(resultEmpty, new List<Address>());
        }

        [TestMethod()]
        public void GetLastAddressTest()
        {
            // Arrange
            var addresses = new List<Address>
            {
                new Address
                {
                    Name = "John",
                    SecondName = "Doe",
                    City = "Warsaw",
                    Country = "Poland",
                    Email = "example@email.com",
                    PostalCode = "00-001",
                },
                new Address
                {
                    Name = "John",
                    SecondName = "Doe",
                    City = "Krakow",
                    Country = "Poland",
                    Email = "example@email.com",
                    PostalCode = "00-002",
                }
            };

            // Act
            _addressBook.AddAddress(addresses[0]);
            Task.Delay(1000).Wait();
            _addressBook.AddAddress(addresses[1]);

            var result = _addressBook.GetLastAddress();

            // Cleanup
            _addressBook.Addresses.Clear();
            _addressBook.SaveAdresses();

            // Assert
            Assert.AreEqual(result, addresses[1]);
        }
    }
}