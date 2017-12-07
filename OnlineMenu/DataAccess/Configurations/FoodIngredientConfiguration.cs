using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configurations
{
    internal class FoodIngredientConfiguration: EntityTypeConfiguration<FoodIngredient>
    {
        public FoodIngredientConfiguration()
        {
            ToTable("FoodIngredients");

            HasKey(ri => new { ri.FoodId, ri.IngredientId });
        }
    }
}
