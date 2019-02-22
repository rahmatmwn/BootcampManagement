using Common.Interface;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Master
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionRepository _religionRepository;
        public ReligionService(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
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
                return _religionRepository.delete(id);
            }
        }

        public List<Religion> Get()
        {
            return _religionRepository.Get();
        }

        public Religion Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _religionRepository.Get(id);
            }
        }

        public bool insert(ReligionParam religionParam)
        {
            return _religionRepository.insert(religionParam);
        }

        public bool update(int? id, ReligionParam religionParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _religionRepository.update(id, religionParam);
            }
        }
    }
}
