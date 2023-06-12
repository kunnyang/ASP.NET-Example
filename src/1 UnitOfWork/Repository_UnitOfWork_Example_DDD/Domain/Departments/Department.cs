using Domain.Base;
using Domain.Users;

namespace Domain.Departments;

public partial class Department : AuditEntity<short>
{
    public Department()
    {
    }

    public string? DepartmentName { get; set; }

    public virtual ICollection<User>? Users { get; set; } = new HashSet<User>();
}