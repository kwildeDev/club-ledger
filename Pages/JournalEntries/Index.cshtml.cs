using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubLedger.Data;
using ClubLedger.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ClubLedger.Pages.JournalEntries;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public required IEnumerable<JournalEntry> JournalEntries { get; set; }
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        JournalEntries = _db.JournalEntry;
    }
}
