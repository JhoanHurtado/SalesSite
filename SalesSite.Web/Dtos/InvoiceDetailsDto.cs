namespace SalesSite.Web.Dtos
{
    public class InvoiceDetailsDto
    {
        public int Id { get; set; }
        public int ProducId { get; set; }
        public int Amount { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalProduct { get; set; }
        public int InvoiceId { get; set; }
    }
}
