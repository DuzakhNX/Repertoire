using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext (DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        public DbSet<MyApp.Models.Chauffeur> Chauffeur { get; set; } = default!;
    }
}
