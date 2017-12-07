namespace BusinessLogic.Models
{
    public class FoodIngredientModel
    {
        public int IngredientId { get; set; }
        public int FoodId { get; set; }
        public string IngredientName { get; set; }
        public double Amount { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
