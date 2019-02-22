using Common.Interface.Master;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Master
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityService(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
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
                return _universityRepository.delete(id);
            }
        }

        public List<University> Get()
        {
            return _universityRepository.Get();
        }

        public University Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _universityRepository.Get(id);
            }
        }

        public bool insert(UniversityParam universityParam)
        {
            return _universityRepository.insert(universityParam);
        }

        public bool update(int? id, UniversityParam universityParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _universityRepository.update(id, universityParam);
            }
        }
    }
}
