using Microsoft.EntityFrameworkCore;
using MuffinShack.Entities;
using System;

namespace MuffinShack.Data
{
    public class MuffinContext:DbContext
    {
       public DbSet<Muffin> Muffins { get; set; } // collection that generates commands to write this to database
       public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=MuffinShack;
            Integrated Security=True");
        }
    }
}
