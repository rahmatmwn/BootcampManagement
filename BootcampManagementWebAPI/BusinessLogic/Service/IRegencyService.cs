using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IRegencyService
    {
        bool insert(RegencyParam regencyParam);
        bool update(int? id, RegencyParam regencyParam);
        bool delete(int? id);
        List<Regency> Get();
        Regency Get(int? id);
        List<Regency> GetRegency(int? Id);
    }
}
