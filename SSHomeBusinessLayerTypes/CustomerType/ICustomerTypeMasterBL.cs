using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface ICustomerTypeMasterBL : IBusinessLayer
    {
        IList<CustomerTypeMaster> GetAll();

        Result<CustomerTypeMaster> Add(CustomerTypeMaster customerTypeDetails);

        Result<CustomerTypeMaster> UpdateCustomerTypeDetails(CustomerTypeMaster customertypeeditdetails);

        CustomerTypeMaster GetCustomerTypeDetails(int customerTypeId);
    }
}
