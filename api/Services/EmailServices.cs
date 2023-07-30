using System;
using api.Services.IServices;

namespace api.Services {
    public class EmailServices: IEmailServices {
        public async Task Send(string _, string __)
        {
            // this simulates sending an email
            // leave this delay as 10s to emulate real life
            await Task.Delay(10000);
        }
    }
}