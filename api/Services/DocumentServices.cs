using System;
using api.Services.IServices;

namespace api.Services
{
    public class DocumentServices : IDocumentServices
    {
        public async Task SyncDocumentsFromExternalSource(string _)
        {
            // this simulates sending an email
            // leave this delay as 10s to emulate real life
            await Task.Delay(10000);
        }
    }
}

