using Backend.Models;

namespace Backend.DTO.Entities
{
    public class EmployeeDTO
    {
        public long Employeeid { get; set; }

        public string Fullname { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string Address { get; set; } = null!;

        public string Telephone { get; set; } = null!;

        public DateOnly Firstworkdate { get; set; }

        public DateOnly? Lastworkdate { get; set; }

        public virtual ICollection<ChecksEmployeeDTO> ChecksEmployees { get; set; } = new List<ChecksEmployeeDTO>();

        public virtual ICollection<EmployeesOrderDTO> EmployeesOrders { get; set; } = new List<EmployeesOrderDTO>();
    }
}
