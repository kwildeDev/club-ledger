using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubLedger.Data;
using ClubLedger.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ClubLedger.Pages.Accounts;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IEnumerable<Account> Accounts { get; set; }
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        Accounts = _db.Account;
    }
}
