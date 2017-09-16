using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;

namespace SSHomeBusinessLayerTypes
{
    public interface IEmployeeMasterBL : IBusinessLayer, IDisposable
    {
        List<EmployeeMaster> FindByName(string userName);

        EmployeeMaster FindByEmail(string email);

        Result<EmployeeMaster> Create(EmployeeMaster employeeMaster);

        EmployeeMaster FindById(int userId);

        EmployeeMaster GetPasswordByUserName(string userName);       

        Result<EmployeeMaster> SetPasswordByUserName(string userName, string passwordHash);
    }
}
