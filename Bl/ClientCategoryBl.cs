using CodeFirst_API.DBModels;
using CodeFirst_API.DTOs;
using System.Collections.Generic;

namespace CodeFirst_API.Bl
{
    public class ClientCategoryBl
    {

        public List<ClientCategoryDTO> BuildClientCategoryDTOList(List<ClientCategory> categories)
        {
            var categoriesDTO = new List<ClientCategoryDTO>();


            foreach (ClientCategory item in categories)
            {
                categoriesDTO.Add(new ClientCategoryDTO
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    CreatedAt = item.RegisterDate,
                    Active = item.Active
                });
            }

            return categoriesDTO;
        }



        public ClientCategoryDTO BuildClientCategoryDTO(ClientCategory category)
        {
            var categoryDTO = new ClientCategoryDTO {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CreatedAt = category.RegisterDate,
                Active = category.Active
            };
            return categoryDTO;
        }
    }
}
