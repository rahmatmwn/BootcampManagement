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
    public class PlacementService : IPlacementService
    {
        private readonly IPlacementRepository _placementRepository;
        public PlacementService(IPlacementRepository placementRepository)
        {
            _placementRepository = placementRepository;
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
                return _placementRepository.delete(id);
            }

        }

        public List<Placement> Get()
        {
            return _placementRepository.Get();
        }

        public Placement Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _placementRepository.Get(id);
            }

        }

        public bool insert(PlacementParam placementParam)
        {
            return _placementRepository.insert(placementParam);
        }

        public bool update(int? id, PlacementParam placementParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _placementRepository.update(id, placementParam);

            }
        }
    }
}
