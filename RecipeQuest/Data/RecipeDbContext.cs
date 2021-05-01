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
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRecipe> MemberRecipes { get; set; }
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MemberRecipe>()
                .HasKey(j => new { j.MemberId, j.RecipeId });
            
            
        }

    }
}
