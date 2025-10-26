using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubLedger.Data;
using ClubLedger.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ClubLedger.Pages.ContactTypes;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IEnumerable<ContactType> ContactTypes { get; set; } = new List<ContactType>();
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        ContactTypes = _db.ContactType;
    }
}
