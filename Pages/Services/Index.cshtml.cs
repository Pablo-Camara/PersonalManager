using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalManager.Data;
using PersonalManager.Data.Models;

namespace PersonalManager.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly PersonalManager.Data.ApplicationDbContext _context;

        public IndexModel(PersonalManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Service.ToListAsync();
        }
    }
}
