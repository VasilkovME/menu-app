using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configurations
{
    internal class MenuConfiguration: EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            ToTable("Menu");
            this.HasKey(m => m.MenuId);

            this.Property(m => m.MenuId).
                 HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
                 HasColumnName("MenuId");

            //Many to many relationships with foods;
            this.HasMany(menu => menu.Foods)
                .WithMany(food => food.Menus)
                .Map( cs => 
                {
                    cs.MapLeftKey("FoodId");
                    cs.MapRightKey("MenuId");
                    cs.ToTable("MenuFoods");
                }                
                );
        }
    }
}
