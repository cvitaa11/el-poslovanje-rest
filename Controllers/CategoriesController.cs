using AutoMapper;
using CBBStoreAPI.Data.Categories;
using CBBStoreAPI.VM.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        #region fields
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CategoriesController(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }
        #endregion

        #region implementation
        [HttpGet]
        public ActionResult<IEnumerable<Models.Categories>> GetAllCategories()
        {
            var categories = _categoriesRepository.GetAllCategories();

            if (categories.Any())
            {
                return Ok(categories);
            }

            return StatusCode(204, new { message = "No categories found." });
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriesVM> GetCategoryById(int id)
        {
            var category = _categoriesRepository.GetCategoryById(id);

            if (category != null)
            {
                return Ok(category);
            }

            return StatusCode(404, new { message = "No category found." });
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoriesVM model)
        {
            try
            {
                _categoriesRepository.CreateCategory(_mapper.Map<Models.Categories>(model));
                return StatusCode(200, new { message = "You have successfully created new category." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(CategoriesVM model)
        {
            try
            {
                _categoriesRepository.UpdateCategory(_mapper.Map<Models.Categories>(model));
                return StatusCode(200, new { message = "You have successfully updated category." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _categoriesRepository.GetCategoryById(id);
            try
            {
                _categoriesRepository.DeleteCategory(category);
                return StatusCode(200, new { message = "You have successfully deleted category." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }
        #endregion
    }
}
