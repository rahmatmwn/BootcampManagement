using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IDistrictRepository
    {
        bool insert(DistrictParam districtParam);
        bool update(int? id, DistrictParam districtParam);
        bool delete(int? id);
        List<District> Get();
        District Get(int? id);
        List<District> GetDistrict(int? Id);
    }
}
