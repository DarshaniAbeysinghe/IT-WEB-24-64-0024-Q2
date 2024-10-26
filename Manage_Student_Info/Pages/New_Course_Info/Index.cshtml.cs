using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Manage_Student_Info.Data;
using Manage_Student_Info.Model;

namespace Manage_Student_Info.Pages.New_Course_Info
{
    public class IndexModel : PageModel
    {
        private readonly Manage_Student_Info.Data.Manage_Student_InfoContext _context;

        public IndexModel(Manage_Student_Info.Data.Manage_Student_InfoContext context)
        {
            _context = context;
        }

        public IList<Add_New_Course_Info> Add_New_Course_Info { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Add_New_Course_Info != null)
            {
                Add_New_Course_Info = await _context.Add_New_Course_Info.ToListAsync();
            }
        }
    }
}
