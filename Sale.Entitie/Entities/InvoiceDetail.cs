using System;
using System.Collections.Generic;

namespace Sale.Entitie.Entities
{
    public partial class InvoiceDetail
    {
        public int Id { get; set; }
        public int ProducId { get; set; }
        public int Amount { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalProduct { get; set; }
        public int InvoiceId { get; set; }
    }
}
