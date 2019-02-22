using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface ILessonRepository
    {
        bool insert(LessonParam lessonParam);
        bool update(int? id, LessonParam lessonParam);
        bool delete(int? id);
        List<Lesson> Get();
        Lesson Get(int? id);
    }
}
