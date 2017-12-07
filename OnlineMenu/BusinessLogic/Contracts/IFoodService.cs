using BusinessLogic.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace BusinessLogic.Contracts
{
    public interface IFoodService
    {
        int CreateFood(Food newFood);
        IEnumerable<Food> GetAllFoods();
        Food GetByName(string name);
        Food GetById(int id);
        FoodModel EditFood(FoodModel foodToEdit);
        bool DeleteFood(int foodId);
        IEnumerable<FoodIngredientModel> GetFoodIngredients(int foodId);
        FoodIngredientModel AddFoodIngredient(FoodIngredientModel infredient);
    }
}
