using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manage_Student_Info.Model;

namespace Manage_Student_Info.Data
{
    public class Manage_Student_InfoContext : DbContext
    {
        public Manage_Student_InfoContext (DbContextOptions<Manage_Student_InfoContext> options)
            : base(options)
        {
        }

        public DbSet<Manage_Student_Info.Model.Add_New_Student_Info> Add_New_Student_Info { get; set; } = default!;

        public DbSet<Manage_Student_Info.Model.Add_New_Course_Info>? Add_New_Course_Info { get; set; }
    }
}
