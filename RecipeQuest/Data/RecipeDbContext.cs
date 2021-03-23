using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.Data
{
    public class RecipeDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {

        }
               
    }
}
