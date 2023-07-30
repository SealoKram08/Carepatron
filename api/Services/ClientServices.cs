using api.Data;
using api.Models;
using api.Models.Dto;
using api.Repositories.IConfiguration;
using api.Repositories.IRepositories;
using api.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Services {

    public class ClientServices: IClientServices {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailServices _emailServices;
        private readonly IDocumentServices _documentServices;
        private readonly ILogger<ClientServices> _logger;
        private readonly IMapper _mapper;

        public ClientServices(
            IUnitOfWork unitOfWork, 
            IEmailServices emailServices, 
            IDocumentServices documentServices,
            ILogger<ClientServices> logger,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._emailServices = emailServices;
            this._documentServices = documentServices;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<bool> Create(ClientDto client)
        {
            var result = false;

            try {

                var newClient = _mapper.Map<Client>(client);

                result = await _unitOfWork.ClientRepository.Add(newClient);

                await _unitOfWork.CompleteAsync();

                if (result) {
                    await _emailServices.Send(client.Email, "Hi there - welcome to my Carepatron portal.");
                    await _documentServices.SyncDocumentsFromExternalSource(client.Email);      
                }

            } catch (Exception ex) {
                _logger.LogError(ex, "{Service} Error on Create", typeof(IClientServices));
            }

            return result;
        }

        public async Task<bool> Update(ClientDto client)
        {
            var result = false;

            try
            {
                var updateClient = _mapper.Map<Client>(client);

                var existingRecord = await _unitOfWork.ClientRepository.GetById(updateClient.Id);

                if (existingRecord != null)
                {
                    var sendEmail = false;

                    if (existingRecord.Email != updateClient.Email)
                        sendEmail = true;

                    result = await _unitOfWork.ClientRepository.Update(updateClient);

                    await _unitOfWork.CompleteAsync();

                    if (result && sendEmail)
                    {
                        await _emailServices.Send(client.Email, "Hi there - welcome to my Carepatron portal.");
                        await _documentServices.SyncDocumentsFromExternalSource(client.Email);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Error on Create", typeof(IClientServices));
            }

            return result;
        }

        public async Task<List<Client>> GetAll()
        {
           var clients = await _unitOfWork.ClientRepository.GetAll();

           return clients.ToList();
        }

        public async Task<List<Client>> SearchByName(string name)
        {
            var clients = await _unitOfWork.ClientRepository.GetByName(name);

            return clients.ToList();
        }    
    }
}