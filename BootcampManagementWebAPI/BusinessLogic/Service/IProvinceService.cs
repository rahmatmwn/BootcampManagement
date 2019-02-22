using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IProvinceService
    {
        bool insert(ProvinceParam provinceParam);
        bool update(int? id, ProvinceParam provinceParam);
        bool delete(int? id);
        List<Province> Get();
        Province Get(int? id);
    }
}
