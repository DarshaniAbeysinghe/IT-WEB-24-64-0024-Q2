using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_Student_Info.Data;
using Manage_Student_Info.Model;

namespace Manage_Student_Info.Pages.New_Course_Info
{
    public class EditModel : PageModel
    {
        private readonly Manage_Student_Info.Data.Manage_Student_InfoContext _context;

        public EditModel(Manage_Student_Info.Data.Manage_Student_InfoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Add_New_Course_Info Add_New_Course_Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Add_New_Course_Info == null)
            {
                return NotFound();
            }

            var add_new_course_info =  await _context.Add_New_Course_Info.FirstOrDefaultAsync(m => m.Id == id);
            if (add_new_course_info == null)
            {
                return NotFound();
            }
            Add_New_Course_Info = add_new_course_info;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Add_New_Course_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Add_New_Course_InfoExists(Add_New_Course_Info.Id))
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

        private bool Add_New_Course_InfoExists(int id)
        {
          return (_context.Add_New_Course_Info?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
