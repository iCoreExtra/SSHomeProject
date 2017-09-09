using System.Collections.Generic;
using SSHomeBusinessLayerTypes;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayer
{
    public class EmployeeMasterBL : IEmployeeMasterBL
    {
        private IEmployeeMasterRepository repository;

        public EmployeeMasterBL()
        {
            repository = RepositoryFactory.GetRepository<IEmployeeMasterRepository>();
        }

        public void Dispose()
        {
            repository.Connection.Close();
        }

        public Result<EmployeeMaster> Create(EmployeeMaster employeeMaster)
        {
            return repository.Create(employeeMaster);
        }

        public List<EmployeeMaster> FindByName(string userName)
        {
            return repository.FindByName(userName);
        }

        public EmployeeMaster FindByEmail(string email)
        {
            return repository.FindByEmail(email);
        }       

        public EmployeeMaster FindById(int userId)
        {
            return repository.FindById(userId);
        }

        public EmployeeMaster GetPasswordByUserName(string userName)
        {
            return repository.GetPasswordByUserName(userName);
        }

        public Result<EmployeeMaster> SetPasswordByUserName(string userName, string passwordHash)
        {
            return repository.SetPasswordByUserName(userName, passwordHash);
        }
    }
}
