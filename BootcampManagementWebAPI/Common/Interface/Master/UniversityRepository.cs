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
    public class UniversityRepository : IUniversityRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        University university = new University();
        public bool delete(int? id)
        {
            var result = 0;
            university = myContext.Universities.Find(id);
            university.IsDelete = true;
            university.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<University> Get()
        {
            var getAll = myContext.Universities.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public University Get(int? id)
        {
            var get = myContext.Universities.Find(id);
            return get;
        }

        public bool insert(UniversityParam universityParam)
        {
            var result = 0;
            university.Name = universityParam.Name;
            university.Address = universityParam.Address;
            university.Phone = universityParam.Phone;
            var getVillage = myContext.Villages.Find(universityParam.Villages_Id);
            university.Villages = getVillage;
            university.CreateDate = DateTimeOffset.Now.LocalDateTime;
            university.IsDelete = false;
            myContext.Universities.Add(university);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, UniversityParam universityParam)
        {
            var result = 0;
            university = myContext.Universities.Find(id);
            university.Name = universityParam.Name;
            university.Address = universityParam.Address;
            university.Phone = universityParam.Phone;
            var getVillage = myContext.Villages.Find(universityParam.Villages_Id);
            university.Villages = getVillage;
            university.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
