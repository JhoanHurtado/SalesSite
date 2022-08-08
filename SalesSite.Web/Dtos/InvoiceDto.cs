namespace SalesSite.Web.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public int TotalProducts { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

    }
}
