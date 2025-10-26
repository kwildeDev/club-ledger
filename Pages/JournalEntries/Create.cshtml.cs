using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubLedger.Models;
using ClubLedger.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClubLedger.Pages.JournalEntries
{
    public class CreateModel : PageModel
    {
        private const int BankAccountID = 1010; // Example ID
        private const int PettyCashAccountID = 1000; // Example ID
        private readonly Data.AppDbContext _context;

        public CreateModel(Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JournalEntryViewModel Input { get; set; } = new JournalEntryViewModel
        {
            EntryDate = DateTime.Today,
            OtherAccountID = 0,
            TransactionAmount = 0m,
            Method = JournalEntryViewModel.PaymentMethod.Bank
        };

        public async Task<IActionResult> OnGetAsync()
        {
            Input.ContactOptions = await _context.Contact
                .Select(c => new SelectListItem
                {
                    Value = c.ContactID.ToString(),
                    Text = c.ContactName
                })
                .ToListAsync();

            Input.OtherAccountOptions = await _context.Account
                .Select(a => new SelectListItem
                {
                    Value = a.AccountID.ToString(),
                    Text = a.AccountName
                })
                .ToListAsync();

            return Page();
        }

        private async Task PopulateContactOptionsAsync()
        {
            Input.ContactOptions = await _context.Contact
                .Select(c => new SelectListItem
                {
                    Value = c.ContactID.ToString(),
                    Text = c.ContactName
                })
                .ToListAsync();
        }

        private async Task PopulateAccountOptionsAsync()
        {
            Input.OtherAccountOptions = await _context.Account
                .Select(a => new SelectListItem
                {
                    Value = a.AccountID.ToString(),
                    Text = a.AccountName
                })
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateContactOptionsAsync();
                await PopulateAccountOptionsAsync();
                return Page();
            }

            var journalEntry = new JournalEntry
            {
                EntryDate = Input.EntryDate,
                Description = Input.Description,
                ReferenceNum = Input.ReferenceNum,
                ContactID = Input.ContactID
            };

            _context.JournalEntry.Add(journalEntry);
            await _context.SaveChangesAsync();

            // The EntryID is now generated and available in journalEntry.EntryID

            // 2. --- Determine Ledger Line Logic (The Core Business Rule) ---

            // The transaction amount can be either a DEBIT to the 'other' account 
            // or a CREDIT to the 'other' account, depending on the nature of the transaction.
            // For simplicity, let's assume if it's a payment, the Bank/Cash is credited.
            // If it's a receipt, the Bank/Cash is debited.
            // You'll need to know which is which. For this example, let's assume
            // the user is entering an expense (Bank/Cash is Credited).

            int cashOrBankID = (Input.Method == JournalEntryViewModel.PaymentMethod.Bank)
                               ? BankAccountID
                               : PettyCashAccountID;

            var ledgerLines = new List<LedgerLine>();

            // LINE 1: The User-Defined Account (The Expense/Revenue)
            // This is the Debit side of the entry.
            ledgerLines.Add(new LedgerLine
            {
                EntryID = journalEntry.EntryID,
                AccountID = Input.OtherAccountID,
                DebitAmount = Input.TransactionAmount, // The main account is Debited
                CreditAmount = 0m,
                LineDescription = Input.Description // Inherit header description
            });

            // LINE 2: The Fixed Account (Bank/Petty Cash)
            // This is the Credit side of the entry, ensuring the transaction balances.
            ledgerLines.Add(new LedgerLine
            {
                EntryID = journalEntry.EntryID,
                AccountID = cashOrBankID, // The determined fixed account
                DebitAmount = 0m,
                CreditAmount = Input.TransactionAmount, // Bank/Cash is Credited
                LineDescription = "Via " + Input.Method.ToString() // Add context to description
            });

            // 3. --- Save Ledger Lines to the Second Database ---
            _context.LedgerLine.AddRange(ledgerLines);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}