namespace WebUI.Models.Food
{
    public class FoodIngredientViewModel
    {
        public int FoodId { get; set; }
        public int IngredientId { get; set; }
        public string UnitOfMeasure { get; set; }
        public string IngredientName { get; set; }
        public double Amount { get; set; }
    }
}