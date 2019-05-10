using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalManager.Data;
using PersonalManager.Data.Models;

namespace PersonalManager.Pages_Gateways
{
    public class EditModel : PageModel
    {
        private readonly PersonalManager.Data.ApplicationDbContext _context;

        public EditModel(PersonalManager.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Gateway).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatewayExists(Gateway.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GatewayExists(int id)
        {
            return _context.Gateway.Any(e => e.ID == id);
        }
    }
}
