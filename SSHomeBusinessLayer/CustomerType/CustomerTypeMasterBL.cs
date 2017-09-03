using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeCommon;
using SSHomeDataModel;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;

namespace SSHomeBusinessLayer
{
    public class CustomerTypeMasterBL : BaseBusinessLayer , ICustomerTypeMasterBL
    {
        #region class members

        private ICustomerTypeMasterRepository _repository;

        #endregion private


        #region Constructor

        public CustomerTypeMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<ICustomerTypeMasterRepository>();
        }
        #endregion Constructor

        #region ICustomerTypeMasterBL member
        public IList<CustomerTypeMaster> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<CustomerTypeMaster> Add(CustomerTypeMaster customerTypeDetails)
        {
            return _repository.Add(customerTypeDetails);
        }

        public Result<CustomerTypeMaster> UpdateCustomerTypeDetails(CustomerTypeMaster customertypeeditdetails)
        {
            return _repository.UpdateCustomerTypeDetails(customertypeeditdetails);
        }

        public CustomerTypeMaster GetCustomerTypeDetails(int customerTypeId)
        {
            return _repository.GetCustomerTypeDetails(customerTypeId);
        }

        #endregion
    }
}
