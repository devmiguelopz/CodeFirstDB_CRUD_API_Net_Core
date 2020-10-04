

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_API.DBModels
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(400)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(600)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public virtual ClientCategory ClientCategory { get; set; }

    }
}
