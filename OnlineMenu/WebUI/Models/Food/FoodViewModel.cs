using Domain.Entities;

namespace WebUI.Models.Food
{
    public class FoodViewModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public FoodType FoodType { get; set; }
        public string FoodTypeName
        {
            get { return FoodType.ToString(); }
        }
    }
}