using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IErrorBankService
    {
        bool insert(ErrorBankParam errorbankParam);
        bool update(int? id, ErrorBankParam errorbankParam);
        bool delete(int? id);
        List<ErrorBank> Get();
        ErrorBank Get(int? id);
    }
}
