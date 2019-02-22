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
    public class ClassRepository : IClassRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Class kelas = new Class();
        public bool delete(int? id)
        {
            var result = 0;
            kelas = myContext.Classes.Find(id);
            kelas.IsDelete = true;
            kelas.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Class> Get()
        {
            var getAll = myContext.Classes.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Class Get(int? id)
        {
            var get = myContext.Classes.Find(id);
            return get;
        }

        public bool insert(ClassParam classParam)
        {
            var result = 0;
            kelas.Name = classParam.Name;
            var getDepartment = myContext.Departments.Find(classParam.Department_Id);
            kelas.Departments = getDepartment;
            var getBatch = myContext.Batches.Find(classParam.Batch_Id);
            kelas.Batches = getBatch;
            var getEmployee = myContext.Employees.Find(classParam.Employee_Id);
            kelas.Employees = getEmployee;
            kelas.CreateDate = DateTimeOffset.Now.LocalDateTime;
            kelas.IsDelete = false;
            myContext.Classes.Add(kelas);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, ClassParam classParam)
        {
            var result = 0;
            kelas = myContext.Classes.Find(id);
            kelas.Name = classParam.Name;
            var getDepartment = myContext.Departments.Find(classParam.Department_Id);
            kelas.Departments = getDepartment;
            var getBatch = myContext.Batches.Find(classParam.Batch_Id);
            kelas.Batches = getBatch;
            var getEmployee = myContext.Employees.Find(classParam.Employee_Id);
            kelas.Employees = getEmployee;
            kelas.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
