using AutoMapper;
using CBBStoreAPI.Data.Brands;
using CBBStoreAPI.VM.Brands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        #region fields
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public BrandsController(IMapper mapper, IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
            _mapper = mapper;
        }
        #endregion

        #region implementation
        [HttpGet]
        public ActionResult<IEnumerable<BrandsVM>> GetAllBrands()
        {
            var brands = _brandsRepository.GetAllBrands();

            if (brands.Any())
            {
                return Ok(_mapper.Map<IEnumerable<BrandsVM>>(brands));
            }

            return StatusCode(204, new { message = "No brands found." });
        }

        [HttpGet("{id}")]
        public ActionResult GetBrandById(int id)
        {
            try
            {
                var brand = _brandsRepository.GetBrandById(id);
                return Ok(brand);
            }
            catch (Exception e)
            {
                return StatusCode(404, new { message = "Brand not found." });
            }
        }

        [HttpPost]
        public ActionResult CreateBrand(BrandsVM model)
        {
            try
            {
                _brandsRepository.CreateBrand(_mapper.Map<Models.Brands>(model));
                return StatusCode(200, new { message = "You have successfully created new brand." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBrand(Models.Brands model)
        {
            try
            {
                _brandsRepository.UpdateBrand(model);
                return StatusCode(200, new { message = "You have successfully updated brand." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });   
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBrand(int id)
        {
            var brand = _brandsRepository.GetBrandById(id);
            try
            {
                _brandsRepository.DeleteBrand(brand);

                return StatusCode(200, new { message = "You have successfully deleted brand." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }
        #endregion
    }
}
