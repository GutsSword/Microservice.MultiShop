using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService services;

        public CargoCustomersController(ICargoCustomerService service)
        {
            this.services = service;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = services.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerByID(int id)
        {
            var values = services.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var values = new CargoCustomer
            {
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname,
      
            };

            services.TInsert(values);
            return Ok("CargoCustomer Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            var values = new CargoCustomer
            {
                CargoCustomerId = dto.CargoCustomerId,
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname,
            };
            return Ok("CargoCustomer Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            services.TDelete(id);
            return Ok("CargoCustomer Silindi.");
        }
    }
}
