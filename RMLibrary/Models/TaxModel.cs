namespace RMLibrary.Models
{
    /// <summary>
    /// Represents the taxes applied to the sold/purchased products
    /// </summary>
    public class TaxModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Percent { get; set; }

        public bool DefaultSelectedTax { get; set; }
    }
}