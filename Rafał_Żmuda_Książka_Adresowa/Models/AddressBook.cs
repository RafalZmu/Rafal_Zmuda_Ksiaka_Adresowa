namespace Rafał_Żmuda_Książka_Adresowa.Models
{
    public class AddressBook
    {
        public List<Adress> Adresses { get; set; } = new List<Adress>();


        public void AddAdress(Adress adress)
        {
            throw new NotImplementedException();
        }

        public List<Adress> GetByCity(string city)
        {
            throw new NotImplementedException();
        }
        public Adress GetLastAdress()
        {
            throw new NotImplementedException();
        }
    }
}
