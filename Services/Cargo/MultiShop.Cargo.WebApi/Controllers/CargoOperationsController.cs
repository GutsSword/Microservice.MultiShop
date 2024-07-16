using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.DtoLayer.Dtos.CreateCargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService services;

        public CargoOperationsController(ICargoOperationService services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = services.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationByID(int id)
        {
            var values = services.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            var values = new CargoOperation
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };

            services.TInsert(values);
            return Ok("CargoOperation Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var values = new CargoOperation
            {
                Barcode=dto.Barcode,
                CargoOperationId=dto.CargoOperationId,
                Description = dto.Description,
                OperationDate=dto.OperationDate,
            };
            return Ok("CargoOperation Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            services.TDelete(id);
            return Ok("CargoOperation Silindi.");
        }
    }
}
