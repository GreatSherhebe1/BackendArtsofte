using Backend.Models;

namespace Backend.DTO.Entities
{
    public class EmployeesOrderDTO
    {
        public long Id { get; set; }

        public long Employeeid { get; set; }

        public long Orderid { get; set; }

        public virtual EmployeeDTO Employee { get; set; } = null!;

        public virtual OrderDTO Order { get; set; } = null!;
    }
}
