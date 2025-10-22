using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubLedger.Models
{
    public class LedgerLine
    {
        [Key]
        public int LineID { get; set; }
        [Required]
        public int EntryID { get; set; }
        [Required]
        public required int AccountID { get; set; }
        [Required]
        [Column(TypeName ="money")]
        public required decimal DebitAmount { get; set; }
        [Required]
        [Column(TypeName ="money")]
        public required decimal CreditAmount { get; set; }
        public string? LineDescription { get; set; }
    }
}

