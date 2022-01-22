namespace StoreManagement.Domain
{
    public class ProductDetails : Entity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
