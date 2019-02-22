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
    public class ErrorBankService : IErrorBankService
    {
        private readonly IErrorBankRepository _errorBankRepository;
        public ErrorBankService(IErrorBankRepository errorBankRepository)
        {
            _errorBankRepository = errorBankRepository;
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
                return _errorBankRepository.delete(id);
            }
        }

        public List<ErrorBank> Get()
        {
            return _errorBankRepository.Get();
        }

        public ErrorBank Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _errorBankRepository.Get(id);
            }
        }

        public bool insert(ErrorBankParam errorBankParam)
        {
            return _errorBankRepository.insert(errorBankParam);
        }

        public bool update(int? id, ErrorBankParam errorBankParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _errorBankRepository.update(id,errorBankParam);
            }
        }
    }
}
