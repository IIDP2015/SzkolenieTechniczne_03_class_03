namespace SzkolenieTechniczne3.Core.Domain
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
    }
}