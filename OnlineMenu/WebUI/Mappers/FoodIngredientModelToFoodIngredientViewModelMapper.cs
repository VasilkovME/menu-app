using BusinessLogic.Models;
using Domain.Contracts;
using WebUI.Models.Food;

namespace WebUI.Mappers
{
    public class FoodIngredientModelToFoodIngredientViewModelMapper : IMapper<FoodIngredientModel, FoodIngredientViewModel>
    {
        public FoodIngredientModel Map(FoodIngredientViewModel source)
        {
            return new FoodIngredientModel
            {
                Amount = source.Amount,
                FoodId = source.FoodId,
                IngredientId = source.IngredientId,
                UnitOfMeasure = source.UnitOfMeasure
            };
        }

        public FoodIngredientViewModel Map(FoodIngredientModel source)
        {
            return new FoodIngredientViewModel
            {
                Amount = source.Amount,
                FoodId = source.FoodId,
                IngredientId = source.IngredientId,
                UnitOfMeasure = source.UnitOfMeasure,
                IngredientName = source.IngredientName
            };
        }
    }
}