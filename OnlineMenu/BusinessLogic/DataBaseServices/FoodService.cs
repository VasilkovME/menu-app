using BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Data.Entity;
using BusinessLogic.Models;
using Domain.Contracts;

namespace BusinessLogic.DataBaseServices
{
    public class FoodService : DataBaseService, IFoodService
    {
        IMapper<FoodIngredient, FoodIngredientModel> _foodIngredientMapper;

        public FoodService(IMapper<FoodIngredient, FoodIngredientModel> foodIngredientMapper)
        {
            _foodIngredientMapper = foodIngredientMapper;
        }

        private IDbSet<Food> FoodSet
        {
            get {  return _context.Set<Food>(); }
        }

        public int CreateFood(Food newFood)
        {
            if (!FoodSet.Any(food => newFood.FoodId == food.FoodId))
            {
                FoodSet.Add(newFood);
                SaveChanges();
            }
            
            return -1;
        }

        public bool DeleteFood(int foodId)
        {
            var foodToDelete = FoodSet.FirstOrDefault(food => foodId == food.FoodId);
            if (foodToDelete != null)
            {
                FoodSet.Remove(foodToDelete);
                return SaveChanges() > 0;
            }

            return false;
        }

        public FoodModel EditFood(FoodModel foodToEditModel)
        {
            var foodId = foodToEditModel.FoodId;
            var foodEntity = FoodSet.FirstOrDefault(food => foodId == food.FoodId);

            if (foodEntity != null) {
                foodEntity.FoodType = foodToEditModel.FoodType;
                foodEntity.Name = foodToEditModel.Name;
                var result = SaveChanges();
                return foodToEditModel;
            }

            return null;
        }

        public IEnumerable<Food> GetAllFoods()
        {
            return FoodSet.ToList();
        }

        public Food GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Food GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FoodIngredientModel> GetFoodIngredients(int foodId)
        {
            var query = _context.Set<FoodIngredient>()
                                .Include(food => food.Ingredient)
                                .Where(f => f.FoodId == foodId)
                                .Select(f => new FoodIngredientModel
                                {
                                    FoodId = f.FoodId,
                                    IngredientId = f.IngredientId,
                                    IngredientName = f.Ingredient.Name,
                                    Amount = f.Amount,
                                    UnitOfMeasure = f.UnitOfMeasure
                                });


            return query.ToList();
        }

        public FoodIngredientModel AddFoodIngredient(FoodIngredientModel ingredientModel)
        {
            var foodId = ingredientModel.FoodId;
            var food = FoodSet.FirstOrDefault(f => f.FoodId == foodId);

            if (food != null)
            {
                var ingredient = _foodIngredientMapper.Map(ingredientModel);
                food.Ingredients.Add(ingredient);
                SaveChanges();
                return ingredientModel;
            }

            return null;
        }
    }
}
