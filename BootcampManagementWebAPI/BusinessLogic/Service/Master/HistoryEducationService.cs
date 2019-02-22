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
    public class HistoryEducationService : IHistoryEducationService
    {
        private readonly IHistoryEducationRepository _historyEducationRepository;
        public HistoryEducationService(IHistoryEducationRepository historyEducationRepository)
        {
            _historyEducationRepository = historyEducationRepository;
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
                return _historyEducationRepository.delete(id);
            }
        }

        public List<HistoryEducation> Get()
        {
            return _historyEducationRepository.Get();
        }

        public HistoryEducation Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _historyEducationRepository.Get(id);
            }
        }

        public bool insert(HistoryEducationParam historyEducationParam)
        {
            return _historyEducationRepository.insert(historyEducationParam);
        }

        public bool update(int? id, HistoryEducationParam historyEducationParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _historyEducationRepository.update(id, historyEducationParam);
            }
        }
    }
}
