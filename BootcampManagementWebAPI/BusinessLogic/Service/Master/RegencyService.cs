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
    public class RegencyService : IRegencyService
    {
        private readonly IRegencyRepository _regencyRepository;
        public RegencyService(IRegencyRepository regencyRepository)
        {
            _regencyRepository = regencyRepository;
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
                return _regencyRepository.delete(id);
            }
        }

        public List<Regency> Get()
        {
            return _regencyRepository.Get();
        }

        public Regency Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _regencyRepository.Get(id);
            }
        }

        public List<Regency> GetRegency(int? Id)
        {
            return _regencyRepository.GetRegency(Id);
        }

        public bool insert(RegencyParam regencyParam)
        {
            return _regencyRepository.insert(regencyParam);
        }

        public bool update(int? id, RegencyParam regencyParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _regencyRepository.update(id, regencyParam);
            }
        }
    }
}
