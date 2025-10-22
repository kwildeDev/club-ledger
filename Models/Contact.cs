using System.ComponentModel.DataAnnotations;

namespace ClubLedger.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required]
        public required string ContactName { get; set; }
        [Required]
        public required int ContactTypeID { get; set; }
    }
}

