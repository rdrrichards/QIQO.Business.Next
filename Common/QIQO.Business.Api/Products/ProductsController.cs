using Microsoft.AspNetCore.Mvc;
using QIQO.Products.Domain;
using QIQO.Products.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsManager _productsManager;

        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Product1", "Product2" });
            return Ok(await _productsManager.GetProductsAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productsManager.GetProductAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductAddViewModel productAddViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productsManager.SaveProductAsync(new Product(productAddViewModel.ProductCode, productAddViewModel.ProductName, productAddViewModel.ProductDesc,
                    productAddViewModel.ProductNameShort, productAddViewModel.ProductNameLong, productAddViewModel.ProductImagePath));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]ProductUpdateViewModel productUpdateViewModel)
        {
            await _productsManager.UpdateProductAsync(new Product(productUpdateViewModel.ProductName, productUpdateViewModel.ProductDesc,
                    productUpdateViewModel.ProductNameShort, productUpdateViewModel.ProductNameLong, productUpdateViewModel.ProductImagePath));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productsManager.DeleteProductAsync(id);
            return Ok();
        }
    }
}
