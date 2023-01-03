using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Data
{
    public class To_Do_ListContext : DbContext
    {
        public To_Do_ListContext (DbContextOptions<To_Do_ListContext> options)
            : base(options)
        {
        }

        public DbSet<To_Do_List.Models.To_Do> To_Do { get; set; } = default!;
    }
}
