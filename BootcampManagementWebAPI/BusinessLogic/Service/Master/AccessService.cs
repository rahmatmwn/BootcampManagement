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
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;
        public AccessService(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
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
                return _accessRepository.delete(id);
            }

        }

        public List<Access> Get()
        {
            return _accessRepository.Get();
        }

        public Access Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _accessRepository.Get(id);
            }

        }

        public bool insert(AccessParam accessParam)
        {
            return _accessRepository.insert(accessParam);
        }

        public bool update(int? id, AccessParam accessParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _accessRepository.update(id, accessParam);

            }
        }
    }
}
