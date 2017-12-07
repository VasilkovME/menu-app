using Autofac;
using BusinessLogic.Models;
using Domain.Contracts;
using Domain.Entities;
using WebUI.Mappers;
using WebUI.Models.Food;
using WebUI.Models.Ingredient;

namespace WebUI
{
    public class WebUIRegistrationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {           
            builder.RegisterType<FoodToFoodModelMapper>()
                .As<IMapper<Food, FoodViewModel>>();

            builder.RegisterType<IngredientToIngredientViewModelMapper>()
                .As<IMapper<Ingredient, IngredientViewModel>>();

            builder.RegisterType<FoodIngredientModelToFoodIngredientViewModelMapper>()
                .As<IMapper<FoodIngredientModel, FoodIngredientViewModel>>();

            builder.RegisterType<FoodModelToFoodViewModelMapper>()
                .As<IMapper<FoodModel, FoodViewModel>>();

        }
    }
}