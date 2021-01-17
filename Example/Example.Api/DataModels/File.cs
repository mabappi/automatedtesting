using System;
using System.ComponentModel.DataAnnotations;

namespace Example.Api.DataModels
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FileNumber { get; set; }

        [Required]
        public Guid DebtorId { get; set; }

        public Debtor Debtor { get; set; }

        [Required]
        public decimal DueAmount { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }
    }
}
