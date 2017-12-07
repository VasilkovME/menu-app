namespace Domain.Entities
{
    public class FoodIngredient
    {
        public int FoodId { get; set; }
        public int IngredientId { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Amount { get; set; }
              
        public virtual Ingredient Ingredient { get; set; }
        public virtual Food Food { get; set; }
    }
}
