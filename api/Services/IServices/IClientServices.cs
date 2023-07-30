using api.Data;
using api.Models;
using api.Models.Dto;

namespace api.Services.IServices
{
    public interface IClientServices
    {
        Task<List<Client>> GetAll();
        Task<bool> Create(ClientDto client);
        Task<bool> Update(ClientDto client);
        Task<List<Client>> SearchByName(string name);
    }
}