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
    public class WeeklyScoreService : IWeeklyScoreService
    {
        private readonly IWeeklyScoreRepository _weeklyScoreRepository;
        public WeeklyScoreService(IWeeklyScoreRepository weeklyScoreRepository)
        {
            _weeklyScoreRepository = weeklyScoreRepository;
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
                return _weeklyScoreRepository.delete(id);
            }
        }

        public List<WeeklyScore> Get()
        {
            return _weeklyScoreRepository.Get();
        }

        public WeeklyScore Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _weeklyScoreRepository.Get(id);
            }
        }

        public bool insert(WeeklyScoreParam weeklyScoreParam)
        {
            return _weeklyScoreRepository.insert(weeklyScoreParam);
        }

        public bool update(int? id, WeeklyScoreParam weeklyScoreParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _weeklyScoreRepository.update(id, weeklyScoreParam);
            }
        }
    }
}
