using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IEmployeeService
    {
        bool insert(EmployeeParam employeeParam);
        bool update(int? id, EmployeeParam employeeParam);
        bool delete(int? id);
        List<Employee> Get();
        Employee Get(int? id);
    }
}
