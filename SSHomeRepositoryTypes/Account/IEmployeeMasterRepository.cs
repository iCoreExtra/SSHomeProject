using SSHomeDataModel;
using System.Collections.Generic;

namespace SSHomeRepositoryTypes
{
    public interface IEmployeeMasterRepository : IRepository
    {
        EmployeeMaster Create(EmployeeMaster employeeMaster);

        List<EmployeeMaster> FindByName(string userName);

        EmployeeMaster FindByEmail(string email);
    }
}
