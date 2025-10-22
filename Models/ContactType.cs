using System.ComponentModel.DataAnnotations;

namespace ClubLedger.Models
{
    public class ContactType
    {
        [Key]
        public int ContactTypeID { get; set; }
        [Required]
        public required string ContactTypeName { get; set; }
    }
}

