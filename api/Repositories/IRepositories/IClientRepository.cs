using api.Models;
using System;
using System.Threading.Tasks;

namespace api.Repositories.IRepositories
{
    public interface IClientRepository: IGenericRepository<Client>
    {
         Task<IEnumerable<Client>> GetByName(string name);
    }
}
