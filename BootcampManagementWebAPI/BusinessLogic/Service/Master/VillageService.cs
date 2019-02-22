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
    public class VillageService : IVillageService
    {
        private readonly IVillageRepository _villageRepository;
        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
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
                return _villageRepository.delete(id);
            }
        }

        public List<Village> Get()
        {
            return _villageRepository.Get();
        }

        public Village Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _villageRepository.Get(id);
            }
        }

        public List<Village> GetVillage(int? Id)
        {
            return _villageRepository.GetVillage(Id);
        }

        public bool insert(VillageParam villageParam)
        {
            return _villageRepository.insert(villageParam);
        }

        public bool update(int? id, VillageParam villageParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _villageRepository.update(id, villageParam);
            }
        }
    }
}
