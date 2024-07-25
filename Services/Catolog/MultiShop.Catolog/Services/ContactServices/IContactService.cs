using MultiShop.Catolog.Dtos.ContactDtos;

namespace MultiShop.Catolog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<ResultContactById> GetByIdContactAsync(string id);
        Task UpdateContactAsync(UpdateContactById updateContactById);
        Task DeleteContactAsync(string id);
        Task CreateContactAsync(CreateContactDto createContactDto);
    }
}
