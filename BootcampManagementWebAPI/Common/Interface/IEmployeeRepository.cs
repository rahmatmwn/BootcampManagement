using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IEmployeeRepository
    {
        bool insert(EmployeeParam employeeParam);
        bool update(int? id, EmployeeParam employeeParam);
        bool delete(int? id);
        List<Employee> Get();
        Employee Get(int? id);
    }
}
