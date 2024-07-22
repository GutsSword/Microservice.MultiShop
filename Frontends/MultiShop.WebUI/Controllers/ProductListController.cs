using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        [Route("ProductList/Index/{categoryId?}")]
        public IActionResult Index(string categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}
