using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class ProgramsContext : DbContext
    {
        public ProgramsContext (DbContextOptions<ProgramsContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Programs> Programs { get; set; }
    }
}
