using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService services;

        public CargoDetailsController(ICargoDetailService services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = services.TGetAll();
            return Ok( values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailByID(int id)
        {
            var values = services.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            var values = new CargoDetail
            {
                Barcode = dto.Barcode,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer,
                CargoCompanyId = dto.CargoCompanyId,
                
            };

            services.TInsert(values);
            return Ok("CargoDetail Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var values = new CargoDetail
            {
                CargoDetailId = dto.CargoDetailId,
                Barcode = dto.Barcode,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer,
                CargoCompanyId = dto.CargoCompanyId,
            };
            return Ok("CargoDetail Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            services.TDelete(id);
            return Ok("CargoDetail Silindi.");
        }
    }
}
