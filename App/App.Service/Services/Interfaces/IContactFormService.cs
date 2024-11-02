using App.Service.Models.ContactFormDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IContactFormService
    {
        Task AddContactForm(AddContactFormDto contactForm);
    }
}
