using RMLibrary.Models.Helpers;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a Table inside/outside the restaurant, where clients sit and order/buy products
    /// Orders are done for each table cumulating the ordered products.
    /// </summary>
    public class TableModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}