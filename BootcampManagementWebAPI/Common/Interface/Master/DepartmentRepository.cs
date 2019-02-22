using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class DepartmentRepository : IDepartmentRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Department department = new Department();
        public bool delete(int? id)
        {
            var result = 0;
            department = myContext.Departments.Find(id);
            department.IsDelete = true;
            department.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Department> Get()
        {
            var getAll = myContext.Departments.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Department Get(int? id)
        {
            var get = myContext.Departments.Find(id);
            return get;
        }

        public bool insert(DepartmentParam departmentParam)
        {
            var result = 0;
            department.Name = departmentParam.Name;
            department.CreateDate = DateTimeOffset.Now.LocalDateTime;
            department.IsDelete = false;
            myContext.Departments.Add(department);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, DepartmentParam departmentParam)
        {
            var result = 0;
            department = myContext.Departments.Find(id);
            department.Name = departmentParam.Name;
            department.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
