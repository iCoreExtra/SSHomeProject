using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;
using SSHomeDataModel;

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

        public List<EmployeeMaster> FindByName(string userName)
        {
            return repository.FindByName(userName);
        }

        public EmployeeMaster FindByEmail(string email)
        {
            return repository.FindByEmail(email);
        }
    }
}
