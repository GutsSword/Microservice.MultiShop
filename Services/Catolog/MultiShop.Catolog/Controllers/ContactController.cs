using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.ContactDtos;
using MultiShop.Catolog.Services.ContactServices;

namespace MultiShop.Catolog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var values = await contactService.GetAllContact();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContact (string id)
        {
            var values = await contactService.GetByIdContactAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await contactService.CreateContactAsync(createContactDto);
            return Ok("Mesaj Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await contactService.DeleteContactAsync(id);
            return Ok("Mesaj Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateContactById updateContactById)
        {
            await contactService.UpdateContactAsync(updateContactById);
            return Ok("Mesaj Başarıyla Güncellendi");
        }
    }
}
