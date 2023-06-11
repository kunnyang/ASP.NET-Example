using Repository_UnitOfWork_Example.Entities.Audit;

namespace Repository_UnitOfWork_Example.Entities.Models;

public class Department : AuditEntity<short>
{
    public string? DepartmentName { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}