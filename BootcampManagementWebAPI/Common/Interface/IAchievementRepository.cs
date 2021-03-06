﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IAchievementRepository
    {
        bool insert(AchievementParam achievementParam);
        bool update(int? id, AchievementParam achievementParam);
        bool delete(int? id);
        List<Achievement> Get();
        Achievement Get(int? id);
    }
}
