using App.Eticaret.Models.ViewModels.ContactForm;
using App.Service.Models.ContactFormDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class ContactFormProfile : Profile
    {
        public ContactFormProfile()
        {
            CreateMap<CreateContactFormMessageViewModel, AddContactFormDto>();
        }
    }
}
