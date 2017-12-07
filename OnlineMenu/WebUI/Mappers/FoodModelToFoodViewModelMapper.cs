using BusinessLogic.Models;
using Domain.Contracts;
using WebUI.Models.Food;

namespace WebUI.Mappers
{
    public class FoodModelToFoodViewModelMapper : IMapper<FoodModel, FoodViewModel>
    {
        public FoodModel Map(FoodViewModel source)
        {
            return new FoodModel {  FoodId = source.FoodId, FoodType = source.FoodType, Name = source.Name };
        }

        public FoodViewModel Map(FoodModel source)
        {
            return new FoodViewModel { FoodId = source.FoodId, FoodType = source.FoodType, Name = source.Name };
        }
    }
}