using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.Master
{
    public class EmployeeRepository : IEmployeeRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Employee employee = new Employee();
        public bool delete(int? id)
        {
            var result = 0;
            employee = myContext.Employees.Find(id);
            employee.IsDelete = true;
            employee.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Employee> Get()
        {
            var getAll = myContext.Employees.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Employee Get(int? id)
        {
            var get = myContext.Employees.Find(id);
            return get;
        }

        public bool insert(EmployeeParam employeeParam)
        {
            var result = 0;
            employee.First_Name = employeeParam.First_Name;
            employee.Last_Name = employeeParam.Last_Name;
            employee.Date_Of_Birth = employeeParam.Date_Of_Birth;
            employee.Place_Of_Birth = employeeParam.Place_Of_Birth;
            employee.Gender = employeeParam.Gender;
            employee.Address = employeeParam.Address;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Secret_Question = employeeParam.Secret_Question;
            employee.Secret_Answer = employeeParam.Secret_Answer;
            employee.Role = employeeParam.Role;
            var getReligion = myContext.Religions.Find(employeeParam.Religions_Id);
            employee.Religions = getReligion;
            var getVillage = myContext.Villages.Find(employeeParam.Villages_Id);
            employee.Villages = getVillage;
            employee.CreateDate = DateTimeOffset.Now.LocalDateTime;
            employee.IsDelete = false;
            myContext.Employees.Add(employee);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            employee = myContext.Employees.Find(id);
            employee.First_Name = employeeParam.First_Name;
            employee.Last_Name = employeeParam.Last_Name;
            employee.Date_Of_Birth = employeeParam.Date_Of_Birth;
            employee.Place_Of_Birth = employeeParam.Place_Of_Birth;
            employee.Gender = employeeParam.Gender;
            employee.Address = employeeParam.Address;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Secret_Question = employeeParam.Secret_Question;
            employee.Secret_Answer = employeeParam.Secret_Answer;
            employee.Role = employeeParam.Role;
            var getReligion = myContext.Religions.Find(employeeParam.Religions_Id);
            employee.Religions = getReligion;
            var getVillage = myContext.Villages.Find(employeeParam.Villages_Id);
            employee.Villages = getVillage;
            employee.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
