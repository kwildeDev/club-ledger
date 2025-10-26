using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubLedger.Data;
using ClubLedger.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ClubLedger.Pages.AccountTypes;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IEnumerable<AccountType> AccountTypes { get; set; } = new List<AccountType>();
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        AccountTypes = _db.AccountType;
    }
}
