using AspectOriented.Business.Shared.Services;
using AspectOriented.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspectOriented.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            Stopwatch? watch = Stopwatch.StartNew();
            IEnumerable<string>? result = _productService.GetAll();
            watch.Stop();
            return Ok(new ResponseModel<IEnumerable<string>>(result, watch.ElapsedMilliseconds));
        }
    }
}