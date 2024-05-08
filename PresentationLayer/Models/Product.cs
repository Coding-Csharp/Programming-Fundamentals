namespace PresentationLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Price = 0;
            this.Stock = 0;
        }
    }
    public partial class Product
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public short Stock { get; set; }
    }
}