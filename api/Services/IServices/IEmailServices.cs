using System;

namespace api.Services.IServices
{
    public interface IEmailServices {
        Task Send(string email, string message);
    }
}