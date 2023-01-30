using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpGet("getbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var res = _productService.Add(product);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var res = _productService.Update(product);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var res = _productService.Delete(product);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}
