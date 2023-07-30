using api.Data;
using api.Models;
using api.Repositories.IRepositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories {
    public class ClientRepository: GenericRepository<Client>, IClientRepository {

        public ClientRepository(
            DataContext dataContext,
            ILogger logger): base(dataContext, logger)
        {

        }

        public override async Task<bool> Update(Client entity)
        {
            var result = false;
            
            try {

                var existingClient = await dbSet.Where(a => a.Id == entity.Id).FirstOrDefaultAsync();

                if (existingClient != null) {
                    existingClient.FirstName = entity.FirstName;
                    existingClient.LastName = entity.LastName;
                    existingClient.PhoneNumber = entity.PhoneNumber;
                    existingClient.Email = entity.Email;
                    
                    result = true;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error on class {Repo} ", typeof(ClientRepository));
            }

            return result;
        }

        public async Task<IEnumerable<Client>> GetByName(string name)
        {
            IQueryable<Client> clients = null;

            try {

                await Task.Run(() => {
                    clients =  dbSet.Where(cl => string.Compare(cl.FirstName, name, true) == 0 || string.Compare(cl.LastName, name, true) == 0);
                });

            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Error on class {Repo} ", typeof(ClientRepository));
            }

            return clients;
        }
    }
}