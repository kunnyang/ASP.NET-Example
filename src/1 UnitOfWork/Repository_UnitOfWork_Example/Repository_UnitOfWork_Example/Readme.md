# unit of work

## CRUD 方法不暴露到仓储

```C#
// 不继承IRepository<Salary>
public interface ISalaryRepository /*: IRepository<Salary>*/{}

// SalaryRepository继承
internal class SalaryRepository : Repository<Salary>, ISalaryRepository

```
