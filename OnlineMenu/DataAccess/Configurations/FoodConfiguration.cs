using Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Configurations
{
    internal class FoodConfiguration: EntityTypeConfiguration<Food>
    {
        public FoodConfiguration()
        {
            this.ToTable("Food");
            this.HasKey(food => food.FoodId);

            this.Property(food=>food.FoodId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("FoodId");

            this.Property(food => food.Name)
                .IsRequired();

            this.HasMany(food => food.Ingredients)
                .WithRequired(i => i.Food)
                .HasForeignKey(i=>i.FoodId);
        }
    }
}
