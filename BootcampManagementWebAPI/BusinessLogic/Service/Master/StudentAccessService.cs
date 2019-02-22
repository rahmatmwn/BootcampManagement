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
    public class StudentAccessService : IStudentAccessService
    {
        private readonly IStudentAccessRepository _studentAccessRepository;
        public StudentAccessService(IStudentAccessRepository studentAccessRepository)
        {
            _studentAccessRepository = studentAccessRepository;
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
                return _studentAccessRepository.delete(id);
            }
        }

        public List<StudentAccess> Get()
        {
            return _studentAccessRepository.Get();
        }

        public StudentAccess Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _studentAccessRepository.Get(id);
            }
        }

        public bool insert(StudentAccessParam studentAccessParam)
        {
            return _studentAccessRepository.insert(studentAccessParam);
        }

        public bool update(int? id, StudentAccessParam studentAccessParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _studentAccessRepository.update(id, studentAccessParam);

            }
        }
    }
}
