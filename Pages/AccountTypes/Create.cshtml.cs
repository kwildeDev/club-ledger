using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubLedger.Models;

namespace ClubLedger.Pages.AccountTypes
{
    public class CreateModel : PageModel
    {
        private readonly Data.AppDbContext _context;

        public CreateModel(Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public required AccountType AccountType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || AccountType == null)
            {
                return Page();
            }

            try
            {
                _context.AccountType.Add(AccountType);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
                return Page();
            }   
        }
    }
}