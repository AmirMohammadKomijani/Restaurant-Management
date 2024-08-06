using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }

        public FoodCategory FoodCategory { get; set; }
        [ForeignKey("Chef")]
        public int ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public IList<Customer> customers { get; set; }
    }

    public enum FoodCategory
    {
        Pizza = 1,
        Pasta = 2,
        Burger,
        Kebab,
    }
}
