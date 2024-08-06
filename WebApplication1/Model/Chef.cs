namespace WebApplication1.Model
{
    public class Chef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Food> Foods { get; set; }
    }
}
