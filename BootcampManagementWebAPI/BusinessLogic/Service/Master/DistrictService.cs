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
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
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
                return _districtRepository.delete(id);
            }
        }

        public List<District> Get()
        {
            return _districtRepository.Get();
        }

        public District Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _districtRepository.Get(id);
            }
        }

        public List<District> GetDistrict(int? Id)
        {
            return _districtRepository.GetDistrict(Id);
        }

        public bool insert(DistrictParam districtParam)
        {
            return _districtRepository.insert(districtParam);
        }

        public bool update(int? id, DistrictParam districtParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _districtRepository.update(id, districtParam);
            }
        }
    }
}
