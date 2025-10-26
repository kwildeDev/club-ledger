using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; // For select list item

namespace ClubLedger.ViewModels
{
    public class JournalEntryViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime EntryDate { get; set; } = DateTime.Now;

        [Display(Name = "Notes")]
        public string? Description { get; set; } = string.Empty;

        [Display(Name = "Reference No.")]
        public string? ReferenceNum { get; set; } = string.Empty;

        [Display(Name = "Contact")]
        public int? ContactID { get; set; }

        [Required]
        [Display(Name = "Account (Other Side)")]
        public required int OtherAccountID { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public required decimal TransactionAmount { get; set; }

        public enum PaymentMethod { Bank = 1, PettyCash = 2 }

        [Required]
        [Display(Name = "Paid/Received Via")]
        public required PaymentMethod Method { get; set; }

        public List<SelectListItem> ContactOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> OtherAccountOptions { get; set; } = new List<SelectListItem>();
    }
}
