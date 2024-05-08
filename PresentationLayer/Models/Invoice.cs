namespace PresentationLayer.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            this.Id = 0;
            this.ClientData = new();
            this.SaleDate = DateTime.UtcNow;
            this.InvoiceDetailData = new();
            this.AmountFinal = 0;
        }
    }
    public partial class Invoice
    {
        public int Id { get; set; }
        public Client ClientData { get; set; }
        public DateTime SaleDate { get; set; }
        public InvoiceDetail InvoiceDetailData { get; set; }
        public double AmountFinal { get; set; }
    }
}