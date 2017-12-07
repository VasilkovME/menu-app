using Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Configurations
{
    internal class IngredientConfiguration: EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            this.ToTable("Ingredient");

            this.HasKey(i => i.IngredientId);

            this.Property(i => i.IngredientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(i => i.Name)
                .IsRequired();

            this.HasMany(i => i.ReceipeItems)
                .WithRequired(ri => ri.Ingredient)
                .HasForeignKey(i => i.IngredientId);
        }
    }
}
