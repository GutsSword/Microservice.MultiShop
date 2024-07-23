using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentServiceContext context;

        public CommentsController(CommentServiceContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var values = context.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = context.UserComments.Where(x =>
            x.UserCommentId == id).FirstOrDefault();

            return Ok(values);
        }


        [HttpGet("GetCommentsByProductId")]
        public IActionResult GetCommentsByProductId(string id)
        {
            var values = context.UserComments.Where(x => x.ProductId == id).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComments(CreateCommentDto createCommentDto)
        {
            var mapComment = new UserComment
            {
                CreatedDate = DateTime.Now,
                CommentDetail = createCommentDto.CommentDetail,
                Email = createCommentDto.Email,
                ProductId = createCommentDto.ProductId,
                ImageUrl = createCommentDto.ImageUrl,
                NameSurname = createCommentDto.NameSurname,
                Rating = createCommentDto.Rating,
                Status = createCommentDto.Status,
            };
            context.UserComments.Add(mapComment);
            context.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateComments(UserComment userComment)
        {
            var values = context.UserComments.Update(userComment);
            context.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteComments(UserComment userComment)
        {
            var values = context.UserComments.Remove(userComment);
            context.SaveChanges();
            return Ok("Yorum Başarıyla Silindi.");
        }
    }
}
