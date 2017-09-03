using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IVendorMasterRepository : IRepository
    {
        Result<VendorMaster> Add(VendorMaster vendordetails);

        Result<VendorMaster> VendorUpdate(VendorMaster vendordetails);

        IList<VendorMaster> GetVendorListAll();

        VendorMaster GetVendorDetails(int vendorId);
    }
}
