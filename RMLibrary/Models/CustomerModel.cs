using RMLibrary.Models.Helpers;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a customer ordering food online
    /// </summary>
    public class CustomerModel : IDeliveryMethod
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DeliveryAdress { get; set; }

        public string Name {  get => $"{FirstName} {LastName}"; set => value = "This should not be here!"; }

    }
}