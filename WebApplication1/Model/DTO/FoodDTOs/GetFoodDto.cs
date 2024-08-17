namespace WebApplication1.Model.DTO.FoodDTOs
{
    public class GetFoodDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }

        public FoodCategory FoodCategory { get; set; }
        public int ChefId { get; set; }
    }
}
