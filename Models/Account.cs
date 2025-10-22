using System.ComponentModel.DataAnnotations;

namespace ClubLedger.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        public required string AccountCode { get; set; }
        [Required]
        public required string AccountName { get; set; }
        [Required]
        public required int AccountTypeID { get; set; }
    }
}

