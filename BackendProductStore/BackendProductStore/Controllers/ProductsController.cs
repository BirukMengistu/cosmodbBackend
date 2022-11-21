using BackendProductStore.Model;
using BackendProductStore.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BackendProductStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ProductsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var productModel = new ProductModel
            {
                Id = Guid.NewGuid(),
                PartitionKey = "Product",
                ArticleNumber = product.ArticleNumber,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            _context.Add(productModel);
            await _context.SaveChangesAsync();

            return new OkObjectResult(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _context.Product.ToListAsync());
        }
    }

}
