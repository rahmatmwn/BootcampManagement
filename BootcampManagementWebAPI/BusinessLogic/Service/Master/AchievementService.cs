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
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
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
                return _achievementRepository.delete(id);
            }

        }

        public List<Achievement> Get()
        {
            return _achievementRepository.Get();
        }

        public Achievement Get(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return null;
            }
            else
            {
                return _achievementRepository.Get(id);
            }

        }

        public bool insert(AchievementParam achievementParam)
        {
            return _achievementRepository.insert(achievementParam);
        }

        public bool update(int? id, AchievementParam achievementParam)
        {
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                Console.WriteLine("id must not be empty");
                Console.Read();
                return false;
            }
            else
            {
                return _achievementRepository.update(id, achievementParam);

            }
        }
    }
}
