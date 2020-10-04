using CodeFirst_API.Bl;
using CodeFirst_API.DBContext;
using CodeFirst_API.DBModels;
using CodeFirst_API.DTOs;
using CodeFirst_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CodeFirst_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCategoriesController : ControllerBase
    {
        private DBCodeFirstApiContext _Context { get; set; }

        readonly ClientCategoryBl clientCategoryBl = new ClientCategoryBl();
        readonly LogicValidation logicValidation = new LogicValidation();


        public ClientCategoriesController(DBCodeFirstApiContext context)
        {
            this._Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesFromDataBase = await this._Context.ClientCategory.ToListAsync();
            var categoriesDTO = clientCategoryBl.BuildClientCategoryDTOList(categoriesFromDataBase);
            return Ok(categoriesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categoryFromDataBase = await this._Context.ClientCategory.FindAsync(id);

            if (logicValidation.ValidateIfDataOfNull(categoryFromDataBase))
            {
                return NotFound();
            }

            return Ok(clientCategoryBl.BuildClientCategoryDTO(categoryFromDataBase));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ClientCategoryDTO clientCategory)
        {

            ClientCategory newCategory = new ClientCategory
            {

                CategoryName = clientCategory.CategoryName,
                RegisterDate = clientCategory.CreatedAt ?? DateTime.Now,
                Active = clientCategory.Active
            };

            this._Context.ClientCategory.Add(newCategory);

            try
            {
                await this._Context.SaveChangesAsync();

            }
            catch
            {

                return BadRequest();
            }

            return Ok(clientCategoryBl.BuildClientCategoryDTO(newCategory));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(ClientCategoryDTO clientCategory)
        {
            var categoryFromDataBase = await this._Context.ClientCategory.FindAsync(clientCategory.CategoryId);

            if (logicValidation.ValidateIfDataOfNull(categoryFromDataBase))
            {
                return NotFound();
            }

            categoryFromDataBase.CategoryName = clientCategory.CategoryName;
            categoryFromDataBase.Active = clientCategory.Active;
            this._Context.ClientCategory.Update(categoryFromDataBase);

            try
            {
                await this._Context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return Ok(clientCategoryBl.BuildClientCategoryDTO(categoryFromDataBase));

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryFromDataBase = await this._Context.ClientCategory.FindAsync(id);

            if (logicValidation.ValidateIfDataOfNull(categoryFromDataBase))
            {
                return NotFound();
            }
            this._Context.Remove(categoryFromDataBase);
            try
            {
                await this._Context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
