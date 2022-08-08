namespace SalesSite.Web.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int ProducId { get; set; }
        public int Amount { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalProduct { get; set; }
        public int InvoiceId { get; set; }

    }
}
