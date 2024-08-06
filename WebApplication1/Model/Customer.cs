using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(20)] // ِata Annotation
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastVisit { get; set; }
        public float? Expense { get; set; }
        public IList<Food> food { get; set; }
    }
}
