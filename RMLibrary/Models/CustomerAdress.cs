namespace RMLibrary.Models
{
    public class CustomerAdress
    {
        public int Id { get; set; }

        public Customer CustomerId { get; set; }

        public string Adress { get; set; }
    }
}