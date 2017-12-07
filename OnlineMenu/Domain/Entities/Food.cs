using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public FoodType FoodType { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<FoodIngredient> Ingredients { get; set; }
        public Food()
        {
            Menus = new Collection<Menu>();
        }
    }

    public enum FoodType {
        SideDish,
        Soup,
        Salad,
        Meat,
        Fish
    }
}
