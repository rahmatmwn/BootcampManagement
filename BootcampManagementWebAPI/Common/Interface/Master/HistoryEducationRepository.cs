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
    public class HistoryEducationRepository : IHistoryEducationRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        HistoryEducation historyeducation = new HistoryEducation();
        public bool delete(int? id)
        {
            var result = 0;
            historyeducation = myContext.HistoryEducations.Find(id);
            historyeducation.IsDelete = true;
            historyeducation.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<HistoryEducation> Get()
        {
            var getAll = myContext.HistoryEducations.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public HistoryEducation Get(int? id)
        {
            var get = myContext.HistoryEducations.Find(id);
            return get;
        }

        public bool insert(HistoryEducationParam historyEducationParam)
        {
            var result = 0;
            historyeducation.Degree = historyEducationParam.Degree;
            historyeducation.StudyProgram = historyEducationParam.StudyProgram;
            historyeducation.DateStart = historyEducationParam.DateStart;
            historyeducation.DateEnd = historyEducationParam.DateEnd;
            historyeducation.Ipk = historyEducationParam.Ipk;
            var getUniversity = myContext.Universities.Find(historyEducationParam.Universities_Id);
            historyeducation.Universities = getUniversity;
            //var getStudent = myContext.Students.Find(historyEducationParam.Students_Id);
            //historyeducation.Students = getStudent;
            historyeducation.CreateDate = DateTimeOffset.Now.LocalDateTime;
            historyeducation.IsDelete = false;
            myContext.HistoryEducations.Add(historyeducation);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, HistoryEducationParam historyEducationParam)
        {
            var result = 0;
            historyeducation = myContext.HistoryEducations.Find(id);
            historyeducation.Degree = historyEducationParam.Degree;
            historyeducation.StudyProgram = historyEducationParam.StudyProgram;
            historyeducation.DateStart = historyEducationParam.DateStart;
            historyeducation.DateEnd = historyEducationParam.DateEnd;
            historyeducation.Ipk = historyEducationParam.Ipk;
            var getUniversity = myContext.Universities.Find(historyEducationParam.Universities_Id);
            historyeducation.Universities = getUniversity;
            //var getStudent = myContext.Students.Find(historyEducationParam.Students_Id);
            //historyeducation.Students = getStudent;
            historyeducation.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
