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
    public class DailyScoreService : IDailyScoreService
    {
        private readonly IDailyScoreRepository _dailyScoreRepository;
        public DailyScoreService(IDailyScoreRepository dailyScoreRepository)
        {
            _dailyScoreRepository = dailyScoreRepository;
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
                return _dailyScoreRepository.delete(id);
            }
        }

        public List<DailyScore> Get()
        {
            return _dailyScoreRepository.Get();
        }

        public DailyScore Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _dailyScoreRepository.Get(id);
            }
        }

        public bool insert(DailyScoreParam dailyScoreParam)
        {
            return _dailyScoreRepository.insert(dailyScoreParam);
        }

        public bool update(int? id, DailyScoreParam dailyScoreParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _dailyScoreRepository.update(id, dailyScoreParam);
            }
        }
    }
}
