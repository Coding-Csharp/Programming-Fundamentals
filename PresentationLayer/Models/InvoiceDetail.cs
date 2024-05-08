namespace PresentationLayer.Models
{
    public partial class InvoiceDetail
    {
        public InvoiceDetail()
        {
            this.ProductsDataList = [];
            this.Amount = 0;
        }
    }
    public partial class InvoiceDetail
    {
        public List<Product> ProductsDataList { get; set; }
        public double Amount { get; set; }
    }
}