using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interface;

namespace BusinessLogic.Service.Master
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository _workExperienceRepository;
        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository)
        {
            _workExperienceRepository = workExperienceRepository;
        }
        public bool delete(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _workExperienceRepository.delete(id);
            }

        }

        public List<WorkExperience> Get()
        {
            return _workExperienceRepository.Get();
        }

        public WorkExperience Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _workExperienceRepository.Get(id);
            }

        }

        public bool insert(WorkExperienceParam workExperienceParam)
        {
            return _workExperienceRepository.insert(workExperienceParam);
        }

        public bool update(int? id, WorkExperienceParam workExperienceParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _workExperienceRepository.update(id, workExperienceParam);

            }
        }
    }
}
