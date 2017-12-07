using Domain.Contracts;
using Domain.Entities;
using WebUI.Models.Food;

namespace WebUI.Mappers
{
    public class FoodToFoodModelMapper : IMapper<Food, FoodViewModel>
    {
        public Food Map(FoodViewModel source)
        {
            return new Food
            {
                FoodId = source.FoodId,
                FoodType = source.FoodType,
                Name = source.Name
            };
        }

        public FoodViewModel Map(Food source)
        {
            return new FoodViewModel
            {
                FoodId = source.FoodId,
                FoodType = source.FoodType,
                Name = source.Name
            };
        }
    }
}