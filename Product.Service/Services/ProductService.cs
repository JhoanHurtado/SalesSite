using Microsoft.EntityFrameworkCore;
using Product.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using prod = Product.Entitie.Entities;

namespace Product.Service.Services
{
    public class ProductService: IProduct
    {
        private readonly prod.AppDbContext _dbContext;

        public ProductService(prod.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<prod.Product> Add(prod.Product p)
        {
            _dbContext.Entry(p).State = EntityState.Added;
            try
            {
                _ = await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return p;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await _dbContext.Set<prod.Product> ().FindAsync(id);

            _dbContext.Entry(p).State = EntityState.Deleted;

            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<prod.Product>> Find(Expression<Func<prod.Product, bool>> filtro)
        {
            return await _dbContext.Set<prod.Product>().Where(filtro).ToListAsync();
        }

        public async Task<List<prod.Product>> Get()
        {
            return await _dbContext.Set<prod.Product>().ToListAsync();
        }

        public async Task<bool> Update(prod.Product p)
        {
            _dbContext.Set<prod.Product>().Attach(p);
            _dbContext.Entry(p).State = EntityState.Modified;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
