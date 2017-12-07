using Domain.Contracts;
using Domain.Entities;
using WebUI.Models;
using WebUI.Models.Ingredient;

namespace WebUI.Mappers
{
    public class IngredientToIngredientViewModelMapper : IMapper<Ingredient, IngredientViewModel>
    {
        public Ingredient Map(IngredientViewModel source)
        {
            return new Ingredient
            {
                IngredientId = source.IngredientId,
                Name = source.Name
            };
        }

        public IngredientViewModel Map(Ingredient source)
        {
            return new IngredientViewModel
            {
                Name = source.Name,
                IngredientId = source.IngredientId
            };
        }
    }
}