using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubLedger.Data;
using ClubLedger.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ClubLedger.Pages.Contacts;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public required IEnumerable<Contact> Contacts { get; set; }
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        Contacts = _db.Contact;
    }
}
