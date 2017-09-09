using SSHomeCommon;
using SSHomeDataModel;
using System.Collections.Generic;

namespace SSHomeRepositoryTypes
{
    public interface IEmployeeMasterRepository : IRepository
    {
        Result<EmployeeMaster> Create(EmployeeMaster employeeMaster);

        List<EmployeeMaster> FindByName(string userName);

        EmployeeMaster FindByEmail(string email);

        EmployeeMaster FindById(int userId);

        EmployeeMaster GetPasswordByUserName(string userName);

        Result<EmployeeMaster> SetPasswordByUserName(string userName, string passwordHash);
    }
}
