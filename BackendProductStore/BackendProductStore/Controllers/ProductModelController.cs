using BackendProductStore.Model;
using BackendProductStore.Model.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace BackendProductStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelController : ControllerBase
    {

        private readonly DataBaseContext _context;

        public ProductModelController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            return await _context.Product.ToListAsync();
        }

        // GET: api/ProductModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(Guid id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var productModel = await _context.Product.FindAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }

        // PUT: api/ProductModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(Guid id, ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProductModel(ProductModel productModel)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'DataContext.Products'  is null.");
            }
            _context.Product.Add(productModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductModel", new { id = productModel.Id }, productModel);
        }

        // DELETE: api/ProductModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(Guid id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var productModel = await _context.Product.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelExists(Guid id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}


