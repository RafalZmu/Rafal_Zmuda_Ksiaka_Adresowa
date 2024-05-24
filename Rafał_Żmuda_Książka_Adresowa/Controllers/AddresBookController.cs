using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rafał_Żmuda_Książka_Adresowa.Models;

namespace Rafał_Żmuda_Książka_Adresowa.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddresBookController : Controller
    {
        private readonly IAddressBook _addressBook;
        public AddresBookController(IAddressBook adressBook)
        {
            _addressBook = adressBook;
        }

        [HttpGet]
        public IActionResult GetLastAdress()
        {
            var lastAddress = _addressBook.GetLastAddress();
            return Ok(lastAddress);
        }

        [HttpGet("ByCity")]
        public IActionResult GetByCity(string city)
        {
            var addresses = _addressBook.GetByCity(city);
            return Ok(addresses);
        }

        [HttpPost]
        public IActionResult AddAdress([FromBody] Adress address)
        {
            _addressBook.AddAddress(address);
            return Ok();
        }
    }
}
