using Sale.Entitie.Entities;
using Sale.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sale.Service.Services
{
    public class InvoiceDetailService : ServiceGenerico<InvoiceDetail>, IInvoiceDetail
    {
        private readonly AppDbContext _dbContext;

        public InvoiceDetailService(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
