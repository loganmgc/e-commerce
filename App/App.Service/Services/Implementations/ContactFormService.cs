using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.ContactFormDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class ContactFormService : IContactFormService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ContactFormService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task AddContactForm(AddContactFormDto contactForm)
        {
            var newContactForm = new ContactFormEntity
            {
                Name = contactForm.Name,
                Email = contactForm.Email,
                Message = contactForm.Message,
                SeenAt = null
            };
            await _repositoryManager.ContactFormRepository.AddAsync(newContactForm);
            await _repositoryManager.ContactFormRepository.SaveAsync();
        }
    }
}
