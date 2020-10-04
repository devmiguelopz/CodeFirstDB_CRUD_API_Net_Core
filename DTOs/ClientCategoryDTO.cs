using System;
using System.ComponentModel.DataAnnotations;


namespace CodeFirst_API.DTOs
{
    public class ClientCategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(400, ErrorMessage = "Only acceptsone or 400 chracters")]
        public string CategoryName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Boolean Active { get; set; }

    }
}
