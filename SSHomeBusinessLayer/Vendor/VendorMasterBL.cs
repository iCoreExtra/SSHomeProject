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
    public class VendorMasterBL : BaseBusinessLayer , IVendorMasterBL
    {
        #region class members

        private IVendorMasterRepository _repository;

        #endregion private


        #region Constructor

        public VendorMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IVendorMasterRepository>();
        }

        #endregion Constructor

        #region IStoreMasterBL member

        public Result<VendorMaster> Add(VendorMaster vendordetails)
        {
            return _repository.Add(vendordetails);
        }

        public IList<VendorMaster> GetVendorListAll()
        {
            return _repository.GetVendorListAll();
        }

        public VendorMaster GetVendorDetails(int vendorId)
        {
            return _repository.GetVendorDetails(vendorId);
        }

        public Result<VendorMaster> VendorUpdate(VendorMaster vendordetails)
        {
            return _repository.VendorUpdate(vendordetails);
        }

        #endregion

    }
}
