using AutoMapper;
using api.Models;
using api.Models.Dto;

namespace api.Models.Profiles 
{
    public class MappingProfile: Profile 
    {
        public MappingProfile() {
           
           CreateMap<ClientDto, Client>().ReverseMap();

        }
    }
}