using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace BusinessLogic.Contracts
{
    public interface IIngredientService
    {
        int CreateIngredient(Ingredient newIngredient);
        IEnumerable<Ingredient> GetAllIngridients();
        IEnumerable<Ingredient> GetByName(string name, SearchOption searchOption);
        Ingredient GetById(int id);
        Ingredient EditIngredient(Ingredient ingredientToEdit);
        bool DeleteIngredient(int ingredientId);
    }
}
