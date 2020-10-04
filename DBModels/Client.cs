

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst_API.DBModels
{
    public class ClientCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(400)]
        public string CategoryName { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }

    }
}
