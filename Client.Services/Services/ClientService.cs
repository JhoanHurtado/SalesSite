using Client.Interface.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using cli = Client.Entities.Entities;

namespace Client.Services.Services
{
    public class ClientService:IClient
    {
        private readonly cli.AppDbContext _dbContext;

        public ClientService(cli.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<cli.Client> Add(cli.Client client)
        {
            _dbContext.Entry(client).State = EntityState.Added;
            try
            {
                _ = await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await _dbContext.Set<cli.Client>().FindAsync(id);

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

        public async Task<List<cli.Client>> Find(Expression<Func<cli.Client, bool>> filtro)
        {
            return await _dbContext.Set<cli.Client>().Where(filtro).ToListAsync();
        }

        public async Task<List<cli.Client>> Get()
        {
            return await _dbContext.Set<cli.Client>().ToListAsync();
        }

        public async Task<bool> Update(cli.Client client)
        {
            _dbContext.Set<cli.Client>().Attach(client);
            _dbContext.Entry(client).State = EntityState.Modified;
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
