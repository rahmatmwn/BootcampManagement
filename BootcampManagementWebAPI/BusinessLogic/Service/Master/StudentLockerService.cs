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
    public class StudentLockerService : IStudentLockerService
    {
        private readonly IStudentLockerRepository _studentLockerRepository;
        public StudentLockerService(IStudentLockerRepository studentLockerRepository)
        {
            _studentLockerRepository = studentLockerRepository;
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
                return _studentLockerRepository.delete(id);
            }

        }

        public List<StudentLocker> Get()
        {
            return _studentLockerRepository.Get();
        }

        public StudentLocker Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _studentLockerRepository.Get(id);
            }
        }

        public bool insert(StudentLockerParam studentLockerParam)
        {
            return _studentLockerRepository.insert(studentLockerParam);
        }

        public bool update(int? id, StudentLockerParam studentLockerParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _studentLockerRepository.update(id, studentLockerParam);

            }
        }
    }
}
