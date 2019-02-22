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
    public class HistoryPlacementService : IHistoryPlacementService
    {
        private readonly IHistoryPlacementRepository _historyPlacementRepository;
        public HistoryPlacementService(IHistoryPlacementRepository historyPlacementRepository)
        {
            _historyPlacementRepository = historyPlacementRepository;
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
                return _historyPlacementRepository.delete(id);
            }

        }

        public List<HistoryPlacement> Get()
        {
            return _historyPlacementRepository.Get();
        }

        public HistoryPlacement Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _historyPlacementRepository.Get(id);
            }


        }

        public bool insert(HistoryPlacementParam historyPlacementParam)
        {
            return _historyPlacementRepository.insert(historyPlacementParam);
        }

        public bool update(int? id, HistoryPlacementParam historyPlacementParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _historyPlacementRepository.update(id, historyPlacementParam);

            }
        }
    }
}
