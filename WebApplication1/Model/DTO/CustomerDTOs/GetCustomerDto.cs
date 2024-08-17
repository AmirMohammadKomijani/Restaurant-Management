using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.DTO.CustomerDTOs
{
    public class GetCustomerDto
    {
        public int Id { get; set; }

        [MaxLength(20)] // ِata Annotation
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastVisit { get; set; }
        public float? Expense { get; set; }
    }
}
