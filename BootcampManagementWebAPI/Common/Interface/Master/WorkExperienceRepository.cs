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
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        WorkExperience workExperience = new WorkExperience();
        public bool delete(int? id)
        {
            var result = 0;
            workExperience = myContext.WorkExperiences.Find(id);
            workExperience.IsDelete = true;
            workExperience.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public List<WorkExperience> Get()
        {
            var getAll = myContext.WorkExperiences.Where(x => x.IsDelete == false).ToList();
            return getAll;

        }

        public WorkExperience Get(int? id)
        {
            var get = myContext.WorkExperiences.Find(id);
            return get;
        }

        public bool insert(WorkExperienceParam workExperienceParam)
        {
            var result = 0;
            workExperience.Name = workExperienceParam.Name;
            workExperience.Position = workExperienceParam.Position;
            workExperience.DateStart = workExperienceParam.DateStart;
            workExperience.DateEnd = workExperienceParam.DateEnd;
            var getStudent = myContext.Students.Find(workExperienceParam.Student_Id);
            workExperience.Students = getStudent;
            workExperience.CreateDate = DateTimeOffset.Now.LocalDateTime;
            workExperience.IsDelete = false;
            myContext.WorkExperiences.Add(workExperience);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public bool update(int? id, WorkExperienceParam workExperienceParam)
        {
            var result = 0;
            workExperience = myContext.WorkExperiences.Find(id);
            workExperience.Name = workExperienceParam.Name;
            workExperience.Position = workExperienceParam.Position;
            workExperience.DateStart = workExperienceParam.DateStart;
            workExperience.DateEnd = workExperienceParam.DateEnd;
            var getStudent = myContext.Students.Find(workExperienceParam.Student_Id);
            workExperience.Students = getStudent;
            workExperience.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            workExperience.IsDelete = false;
            myContext.WorkExperiences.Add(workExperience);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
