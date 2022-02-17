using AspectOriented.Business.Shared.Services;
using AspectOriented.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspectOriented.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AspectProductController : ControllerBase
    {
        private readonly IProductServiceAspect _productServiceAspect;

        public AspectProductController(IProductServiceAspect productServiceAspect)
        {
            _productServiceAspect = productServiceAspect;
        }

        [HttpGet(Name = "GetAllAspectProducts")]
        public IActionResult GetAllProducts()
        {
            Stopwatch? watch = Stopwatch.StartNew();
            IEnumerable<string>? result = _productServiceAspect.GetAll();
            watch.Stop();
            return Ok(new ResponseModel<IEnumerable<string>>(result, watch.ElapsedMilliseconds));
        }
    }
}