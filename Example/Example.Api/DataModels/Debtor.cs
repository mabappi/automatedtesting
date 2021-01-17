using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example.Api.DataModels
{
    public class Debtor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
