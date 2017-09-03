using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface IEmployeeMasterBL : IBusinessLayer, IDisposable
    {
        List<EmployeeMaster> FindByName(string userName);

        EmployeeMaster FindByEmail(string email);
    }
}
