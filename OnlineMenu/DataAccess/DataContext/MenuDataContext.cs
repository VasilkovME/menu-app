using DataAccess.Configurations;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MenuDataContext: DbContext
    {
        public MenuDataContext(): base("MenuDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MenuDataContext, DataAccess.Migrations.Configuration>("MenuDB"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Food>(new FoodConfiguration());
            modelBuilder.Configurations.Add<Menu>(new MenuConfiguration());
            modelBuilder.Configurations.Add<Ingredient>(new IngredientConfiguration());
            modelBuilder.Configurations.Add<FoodIngredient>(new FoodIngredientConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
