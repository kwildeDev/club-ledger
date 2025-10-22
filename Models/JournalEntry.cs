using System.ComponentModel.DataAnnotations;

namespace ClubLedger.Models
{
    public class JournalEntry
    {
        [Key]
        public int EntryID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EntryDate { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? ReferenceNum { get; set; } = string.Empty;
        public int? ContactID { get; set; }
    }
}

