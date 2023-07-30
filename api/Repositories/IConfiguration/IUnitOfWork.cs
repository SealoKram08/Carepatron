using System.Threading.Tasks;
using api.Repositories.IRepositories;

namespace api.Repositories.IConfiguration {
    public interface IUnitOfWork {
        IClientRepository ClientRepository { get; }
        Task CompleteAsync();
    }
}