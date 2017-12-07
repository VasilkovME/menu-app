using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FoodIngredient> ReceipeItems { get; set; }

        public Ingredient()
        {
            ReceipeItems = new Collection<FoodIngredient>();
        }
    }
}
