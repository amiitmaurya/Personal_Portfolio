using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio_MVC.Models
{
    public class Contact_me
    {
        [Key]
        public int Id { get; set; }          // ✅ Primary Key (safe)

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }    // ❌ Not PK anymore

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime InsertDate { get; set; }  // DB handles default
    }
}