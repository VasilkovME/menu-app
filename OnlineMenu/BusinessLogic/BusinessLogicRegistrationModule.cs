using Autofac;
using BusinessLogic.Contracts;
using BusinessLogic.DataBaseServices;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using Domain.Contracts;
using Domain.Entities;

namespace BusinessLogic.AutofacModule
{
    public class BusinessLogicRegistrationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IngredientService>()
                   .As<IIngredientService>();

            builder.RegisterType<FoodService>()
                   .As<IFoodService>();

            builder.RegisterType<FoodIngredientToFoodIngredientModelMapper>()
                   .As<IMapper<FoodIngredient, FoodIngredientModel>>();

            base.Load(builder);
        }
    }
}
