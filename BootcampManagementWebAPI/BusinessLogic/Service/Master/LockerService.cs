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
    public class LockerService : ILockerService
    {
        private readonly ILockerRepository _lockerRepository;
        public LockerService(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
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
                return _lockerRepository.delete(id);
            }

        }

        public List<Locker> Get()
        {
            return _lockerRepository.Get();
        }

        public Locker Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _lockerRepository.Get(id);
            }

        }

        public bool insert(LockerParam lockerParam)
        {
            return _lockerRepository.insert(lockerParam);
        }

        public bool update(int? id, LockerParam lockerParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _lockerRepository.update(id, lockerParam);

            }
        }
    }
}
