using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalManager.Data;
using PersonalManager.Data.Models;

namespace PersonalManager.Pages_Gateways
{
    public class DeleteModel : PageModel
    {
        private readonly PersonalManager.Data.ApplicationDbContext _context;

        public DeleteModel(PersonalManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gateway Gateway { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gateway = await _context.Gateway.FirstOrDefaultAsync(m => m.ID == id);

            if (Gateway == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gateway = await _context.Gateway.FindAsync(id);

            if (Gateway != null)
            {
                _context.Gateway.Remove(Gateway);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
