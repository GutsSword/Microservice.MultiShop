using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;


namespace MultiShop.Order.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetail : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler;

        public OrderDetail(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
        {
            this.getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            this.getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            this.createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            this.updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            this.deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetailes()
        {
            var values = await getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int id)
        {
            var values = await getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await createOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await updateOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok("OrderDetail başarıyla silidi.");
        }
    }
}
