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
    public class SkillStudentService : ISkillStudentService
    {
        private readonly ISkillStudentRepository _skillStudentRepository;
        public SkillStudentService(ISkillStudentRepository skillStudentRepository)
        {
            _skillStudentRepository = skillStudentRepository;
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
                return _skillStudentRepository.delete(id);
            }
        }

        public List<SkillStudent> Get()
        {
            return _skillStudentRepository.Get();
        }

        public SkillStudent Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _skillStudentRepository.Get(id);
            }
        }

        public bool insert(SkillStudentParam skillStudentParam)
        {
            return _skillStudentRepository.insert(skillStudentParam);
        }

        public bool update(int? id, SkillStudentParam skillStudentParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _skillStudentRepository.update(id,skillStudentParam);
            }
        }
    }
}
