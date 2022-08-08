using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using prod = Product.Entitie.Entities;

namespace Product.Interface.Interfaces
{
    public interface IProduct
    {
        Task<List<prod.Product>> Get();
        Task<List<prod.Product>> Find(Expression<Func<prod.Product, bool>> filtro);
        Task<prod.Product> Add(prod.Product p);
        Task<bool> Update(prod.Product p);
        Task<bool> Delete(int id);
    }
}
