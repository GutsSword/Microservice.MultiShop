using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService services;

        public CargoCompaniesController(ICargoCompanyService services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = services.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyByID(int id)
        {
            var values = services.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCompany(CreateCargoCompanyDto dto)
        {
            var values = new CargoCompany
            {
                CargoCompanyName = dto.CargoCompanyName,
            };

            services.TInsert(values);
            return Ok("CargoCompany Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var values = new CargoCompany
            {
                CargoCompanyId = dto.CargoCompanyId,
                CargoCompanyName = dto.CargoCompanyName
            };
            return Ok("CargoCompany Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            services.TDelete(id);
            return Ok("CargoCompany Silindi.");
        }
    }
}
