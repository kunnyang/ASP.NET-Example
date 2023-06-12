using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Departments;
using Domain.Salaries;

namespace Domain.Users;

public partial class User:AuditEntity<int>
{
    public User()
    {
    }

    public string UserName { get; set; } = null!;

    [EmailAddress] public string Email { get; set; } = null!;

    public short DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))] public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Salary> Salaries { get; set; } = new HashSet<Salary>();
}