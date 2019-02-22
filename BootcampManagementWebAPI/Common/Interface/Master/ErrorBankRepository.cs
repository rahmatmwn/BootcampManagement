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
    public class ErrorBankRepository : IErrorBankRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        ErrorBank errorbank = new ErrorBank();
        public bool delete(int? id)
        {
            var result = 0;
            errorbank = myContext.ErrorBanks.Find(id);
            errorbank.IsDelete = true;
            errorbank.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<ErrorBank> Get()
        {
            var getAll = myContext.ErrorBanks.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public ErrorBank Get(int? id)
        {
            var get = myContext.ErrorBanks.Find(id);
            return get;
        }

        public bool insert(ErrorBankParam errorBankParam)
        {
            var result = 0;
            errorbank.Message = errorBankParam.Message;
            errorbank.Description = errorBankParam.Description;
            errorbank.Solution = errorBankParam.Solution;
            errorbank.Date = DateTimeOffset.Now.ToLocalTime();
            var getDepartment = myContext.Departments.Find(errorBankParam.Department_Id);
            errorbank.Departments = getDepartment;
            var getStudent = myContext.Students.Find(errorBankParam.Student_Id);
            errorbank.Students = getStudent;

            errorbank.CreateDate = DateTimeOffset.Now.LocalDateTime;
            errorbank.IsDelete = false;
            myContext.ErrorBanks.Add(errorbank);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, ErrorBankParam errorBankParam)
        {
            var result = 0;
            errorbank = myContext.ErrorBanks.Find(id);
            errorbank.Message = errorBankParam.Message;
            errorbank.Description = errorBankParam.Description;
            errorbank.Solution = errorBankParam.Solution;
            errorbank.Date = DateTimeOffset.Now.ToLocalTime();
            var getDepartment = myContext.Departments.Find(errorBankParam.Department_Id);
            errorbank.Departments = getDepartment;
            var getStudent = myContext.Students.Find(errorBankParam.Student_Id);
            errorbank.Students = getStudent;
            errorbank.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
