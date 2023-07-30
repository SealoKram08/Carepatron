using System;
using Microsoft.Extensions.Logging;
using api.Repositories.IConfiguration;
using api.Repositories.IRepositories;
using api.Repositories;

namespace api.Data {
    public class UnitOfWork: IUnitOfWork, IDisposable 
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;
        
        public IClientRepository ClientRepository { get; private set; }

        public UnitOfWork(DataContext dataContext, ILoggerFactory loggerFactory) {
            _dataContext = dataContext;
            _logger = loggerFactory.CreateLogger("logs");

            ClientRepository = new ClientRepository(dataContext, _logger);
        }

        public async Task CompleteAsync() {   
            await _dataContext.SaveChangesAsync();
        }

        public async void Dispose() {
            await _dataContext.DisposeAsync();
        }
    }
}