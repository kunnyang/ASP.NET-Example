using Repository_UnitOfWork_Example.Entities.Audit;

namespace Repository_UnitOfWork_Example.Entities.Models;

public class Salary : AuditEntity<long>
{
    /// <summary>
    ///     工资系数
    /// </summary>
    public float CoefficientsSalary { get; set; }

    public float WorkDays { get; set; }
    public decimal TotalSalary { get; set; }

    public int UserId { get; set; }

    /*[ForeignKey(nameof(UserId))] */
    public virtual User User { get; set; } = null!;
}