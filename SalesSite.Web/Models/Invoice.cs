namespace SalesSite.Web.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int Id { get; set; }
        public DateTime BuyDate { get; set; }
        public decimal Total { get; set; }
        public int TotalProducts { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public virtual Client User { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
