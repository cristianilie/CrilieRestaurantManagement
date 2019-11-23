namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a class that holds information about a company(Supplier/Customer)
    /// </summary>
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string Adress { get; set; }
    }
}