using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using BusinessLogic.Contracts;
using DataAccess;
using System.Data.Entity;
using Domain.Enums;

namespace BusinessLogic.DataBaseServices
{
    public class IngredientService: DataBaseService, IIngredientService
    {
        private IDbSet<Ingredient> IngredientSet
        {
            get { return _context.Set<Ingredient>(); }
        }

        public int CreateIngredient(Ingredient newIngredient)
        {
            if (!IngredientSet.Any(i => i.Name == newIngredient.Name))
            {
                IngredientSet.Add(newIngredient);
                _context.SaveChanges();
                return newIngredient.IngredientId;
            }

            return -1;
        }

        public IEnumerable<Ingredient> GetAllIngridients()
        {
            return IngredientSet.ToList();                
        }

        public Ingredient GetById(int id)
        {
            return IngredientSet.FirstOrDefault(i => i.IngredientId == id);
        }

        public IEnumerable<Ingredient> GetByName(string name, SearchOption searchOption)
        {
            switch (searchOption)
            {
                case SearchOption.FullMatch:
                    return IngredientSet.Where(i => i.Name == name).ToList();
                case SearchOption.Contains:
                    return IngredientSet.Where(i => i.Name.Contains(name)).ToList();
                case SearchOption.StartWith:
                    return IngredientSet.Where(i => i.Name.StartsWith(name)).ToList();
            }

            return new List<Ingredient>();
        }

        public Ingredient EditIngredient(Ingredient ingredientToEdit)
        {
            var dbIngredient = GetById(ingredientToEdit.IngredientId);
            dbIngredient.Name = ingredientToEdit.Name;
            SaveChanges();

            return dbIngredient;
        }

        public bool DeleteIngredient(int ingredientId) {
            var ingredientToDelete = GetById(ingredientId);
            if (ingredientToDelete!=null) {
                IngredientSet.Remove(ingredientToDelete);
                return SaveChanges() > 0;
            }

            return false;
        }
    }
}
