using App.Data.Data.Entities;
using App.Service.Models.ContactFormDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class ContactFormProfile : Profile
    {
        public ContactFormProfile()
        {
            CreateMap<AddContactFormDto, ContactFormEntity>();
        }
    }
}
