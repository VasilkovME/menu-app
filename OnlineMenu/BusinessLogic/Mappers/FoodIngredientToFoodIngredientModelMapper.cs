using BusinessLogic.Models;
using Domain.Contracts;
using Domain.Entities;

namespace BusinessLogic.Mappers
{
    class FoodIngredientToFoodIngredientModelMapper : IMapper<FoodIngredient, FoodIngredientModel>
    {
        public FoodIngredient Map(FoodIngredientModel source)
        {
            return new FoodIngredient
            {
                IngredientId = source.IngredientId,
                FoodId = source.FoodId,
                Amount = source.Amount,
                UnitOfMeasure = source.UnitOfMeasure
            };
        }

        public FoodIngredientModel Map(FoodIngredient source)
        {
            return new FoodIngredientModel
            {
                IngredientId = source.IngredientId,
                FoodId = source.FoodId,
                Amount = source.Amount,
                UnitOfMeasure = source.UnitOfMeasure,
                IngredientName = source.Ingredient.Name
            };
        }
    }
}
