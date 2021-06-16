using DigitalLibraryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public BookContext(DbContextOptions<BookContext> options): base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=DigitalLibraryAPI; Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
