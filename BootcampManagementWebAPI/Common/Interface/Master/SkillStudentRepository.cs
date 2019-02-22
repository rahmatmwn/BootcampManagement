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
    public class SkillStudentRepository : ISkillStudentRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        SkillStudent skillstudent = new SkillStudent();
        public bool delete(int? id)
        {
            var result = 0;
            skillstudent = myContext.SkillStudents.Find(id);
            skillstudent.IsDelete = true;
            skillstudent.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<SkillStudent> Get()
        {
            var getAll = myContext.SkillStudents.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public SkillStudent Get(int? id)
        {
            var get = myContext.SkillStudents.Find(id);
            return get;
        }

        public bool insert(SkillStudentParam skillStudentParam)
        {
            var result = 0;
            var getSkill = myContext.Skills.Find(skillStudentParam.Skill_Id);
            skillstudent.Skills = getSkill;
            var getStudent = myContext.Students.Find(skillStudentParam.Student_Id);
            skillstudent.Students = getStudent;
            skillstudent.CreateDate = DateTimeOffset.Now.LocalDateTime;
            skillstudent.IsDelete = false;
            myContext.SkillStudents.Add(skillstudent);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, SkillStudentParam skillStudentParam)
        {
            var result = 0;
            var getSkill = myContext.Skills.Find(skillStudentParam.Skill_Id);
            skillstudent.Skills = getSkill;
            var getStudent = myContext.Students.Find(skillStudentParam.Student_Id);
            skillstudent.Students = getStudent;
            skillstudent.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
