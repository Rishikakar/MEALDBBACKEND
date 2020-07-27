using System;
using System.Collections.Generic;
using System.Text;
using MealDB1.Entities.Model;
using Microsoft.EntityFrameworkCore;
namespace MealDB1.Entities

{
  public class MealDbContext:DbContext
    {
        public MealDbContext(DbContextOptions<MealDbContext> options) : base(options)
        {

        }

        public DbSet<Meals> Meals { get; set; }
        public DbSet<MainIngredients> MainIngredients { get; set; }
        public DbSet<Countrys> Country { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
