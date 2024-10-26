using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class ContactFormRepository : RepositoryBase<ContactFormEntity>, IContactFormRepository
    {
        public ContactFormRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
