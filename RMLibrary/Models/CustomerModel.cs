namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a customer ordering food online
    /// </summary>
    public class CustomerModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DeliveryAdress { get; set; }

    }
}