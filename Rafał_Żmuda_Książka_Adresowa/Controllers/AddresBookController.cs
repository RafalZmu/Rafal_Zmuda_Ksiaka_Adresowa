using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rafał_Żmuda_Książka_Adresowa.Controllers
{
    public class AddresBookController : Controller
    {

        [HttpGet]
        public IActionResult GetLastAdress()
        {
            return Ok("Ostatni adres");
        }

        [HttpGet]
        public IActionResult GetByCity(string city)
        {
            return Ok("Adresy z miasta: " + city);
        }

        [HttpPost]
        public IActionResult AddAdress([FromBody] string adress)
        {
            return Ok("Dodano adres: " + adress);
        }
    }
}
