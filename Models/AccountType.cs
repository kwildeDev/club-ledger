using System.ComponentModel.DataAnnotations;

namespace ClubLedger.Models
{
    public class AccountType
    {
        [Key]
        public int AccountTypeID { get; set; }
        [Required]
        public required string AccountTypeName { get; set; }
        [Required]
        public required string NormalBalance { get; set; }
    }
}

