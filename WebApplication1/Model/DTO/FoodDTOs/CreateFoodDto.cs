namespace WebApplication1.Model.DTO.FoodDTOs
{
    public class CreateFoodDto
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public FoodCategory FoodCategory { get; set; }
    }
}
