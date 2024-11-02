using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.ContactFormDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class ContactFormService : ServiceBase, IContactFormService
    {
        public ContactFormService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task AddContactForm(AddContactFormDto contactForm)
        {
            var newContactForm = _mapper.Map<ContactFormEntity>(contactForm);
            await _repositoryManager.ContactFormRepository.AddAsync(newContactForm);
            await _repositoryManager.ContactFormRepository.SaveAsync();
        }
    }
}
