using Domain.Entities;

namespace BusinessLogic.Models
{
    public class FoodModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public FoodType FoodType { get; set; }
    }
}
