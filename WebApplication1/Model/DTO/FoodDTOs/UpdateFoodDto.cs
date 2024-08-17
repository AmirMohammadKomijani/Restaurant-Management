namespace WebApplication1.Model.DTO.UpdateFoodDto
{
    public class UpdateFoodDto
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public FoodCategory FoodCategory { get; set; }
        public int ChefId { get; set; }
    }
}
