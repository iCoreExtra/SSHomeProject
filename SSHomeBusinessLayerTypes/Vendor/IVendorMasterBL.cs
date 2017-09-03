using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface IVendorMasterBL : IBusinessLayer
    {
        Result<VendorMaster> Add(VendorMaster vendordetails);

        Result<VendorMaster> VendorUpdate(VendorMaster vendordetails);

        IList<VendorMaster> GetVendorListAll();

        VendorMaster GetVendorDetails(int vendorId);
    }
}
