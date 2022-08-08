using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using cli = Client.Entities.Entities;

namespace Client.Interface.interfaces
{
    public interface IClient
    {
        Task<List<cli.Client>> Get();
        Task<List<cli.Client>> Find(Expression<Func<cli.Client, bool>> filtro);
        Task<cli.Client> Add(cli.Client client);
        Task<bool> Update(cli.Client client);
        Task<bool> Delete(int id);
    }
}
