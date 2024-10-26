﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Manage_Student_Info.Data;
using Manage_Student_Info.Model;

namespace Manage_Student_Info.Pages.New_Student_Info
{
    public class DetailsModel : PageModel
    {
        private readonly Manage_Student_Info.Data.Manage_Student_InfoContext _context;

        public DetailsModel(Manage_Student_Info.Data.Manage_Student_InfoContext context)
        {
            _context = context;
        }

      public Add_New_Student_Info Add_New_Student_Info { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Add_New_Student_Info == null)
            {
                return NotFound();
            }

            var add_new_student_info = await _context.Add_New_Student_Info.FirstOrDefaultAsync(m => m.Id == id);
            if (add_new_student_info == null)
            {
                return NotFound();
            }
            else 
            {
                Add_New_Student_Info = add_new_student_info;
            }
            return Page();
        }
    }
}