using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService= categoryService;
        }


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var res = _categoryService.Add(category);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var res = _categoryService.Update(category);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {
            var res = _categoryService.Delete(category);
            if (res.Success)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }






    }
}
