using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class HistoryPlacementRepository : IHistoryPlacementRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        HistoryPlacement historyPlacement = new HistoryPlacement();
        public bool delete(int? id)
        {
            var result = 0;
            historyPlacement = myContext.HistoryPlacements.Find(id);
            historyPlacement.IsDelete = true;
            historyPlacement.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<HistoryPlacement> Get()
        {
            var getAll = myContext.HistoryPlacements.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public HistoryPlacement Get(int? id)
        {
            var get = myContext.HistoryPlacements.Find(id);
            return get;
        }

        public bool insert(HistoryPlacementParam historyPlacementParam)
        {
            var result = 0;
            historyPlacement.Position = historyPlacementParam.Position;
            historyPlacement.Description = historyPlacementParam.Description;
            historyPlacement.DateStart = historyPlacementParam.DateStart;
            historyPlacement.DateEnd = historyPlacementParam.DateEnd;
            var getUniversity = myContext.Placements.Find(historyPlacementParam.Placement_Id);
            historyPlacement.Placements = getUniversity;
            var getStudent = myContext.Students.Find(historyPlacementParam.Student_Id);
            historyPlacement.Students = getStudent;
            historyPlacement.CreateDate = DateTimeOffset.Now.LocalDateTime;
            historyPlacement.IsDelete = false;
            myContext.HistoryPlacements.Add(historyPlacement);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, HistoryPlacementParam historyPlacementParam)
        {
            var result = 0;
            historyPlacement = myContext.HistoryPlacements.Find(id);
            historyPlacement.Position = historyPlacementParam.Position;
            historyPlacement.Description = historyPlacementParam.Description;
            historyPlacement.DateStart = historyPlacementParam.DateStart;
            historyPlacement.DateEnd = historyPlacementParam.DateEnd;
            var getUniversity = myContext.Placements.Find(historyPlacementParam.Placement_Id);
            historyPlacement.Placements = getUniversity;
            var getStudent = myContext.Students.Find(historyPlacementParam.Student_Id);
            historyPlacement.Students = getStudent;
            historyPlacement.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
