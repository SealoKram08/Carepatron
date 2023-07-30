using System;

namespace api.Services.IServices
{
    public interface IDocumentServices
    {
        Task SyncDocumentsFromExternalSource(string email);
    }
}

