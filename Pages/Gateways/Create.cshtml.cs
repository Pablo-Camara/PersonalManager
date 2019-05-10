using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalManager.Data;
using PersonalManager.Data.Models;

namespace PersonalManager.Pages_Gateways
{
    public class CreateModel : PageModel
    {
        private readonly PersonalManager.Data.ApplicationDbContext _context;

        public CreateModel(PersonalManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Gateway Gateway { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Gateway.Add(Gateway);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}