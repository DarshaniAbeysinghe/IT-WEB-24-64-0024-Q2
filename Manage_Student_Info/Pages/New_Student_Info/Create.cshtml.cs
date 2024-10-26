using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Manage_Student_Info.Data;
using Manage_Student_Info.Model;

namespace Manage_Student_Info.Pages.New_Student_Info
{
    public class CreateModel : PageModel
    {
        private readonly Manage_Student_Info.Data.Manage_Student_InfoContext _context;

        public CreateModel(Manage_Student_Info.Data.Manage_Student_InfoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Add_New_Student_Info Add_New_Student_Info { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Add_New_Student_Info == null || Add_New_Student_Info == null)
            {
                return Page();
            }

            _context.Add_New_Student_Info.Add(Add_New_Student_Info);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
