using Sale.Entitie.Entities;
using Sale.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sale.Service.Services
{
    public class InvoiceService : ServiceGenerico<Invoice>, IInvoice
    {
        private readonly AppDbContext _dbContext;

        public InvoiceService(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
