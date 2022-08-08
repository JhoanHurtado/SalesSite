using System;
using System.Collections.Generic;

namespace Sale.Entitie.Entities
{
    public partial class InvoicePostDto
    {
        public DateTime BuyDate { get; set; }
        public decimal Total { get; set; }
        public int TotalProducts { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
