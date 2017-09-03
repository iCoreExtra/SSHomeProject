using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface IBrandMasterBL: IBusinessLayer
    {
        IList<BrandMaster> GetAll();

        Result<BrandMaster> Add(BrandMaster model);

        Result<BrandMaster> UpdateBrandDetails(BrandMaster brandeditdetails);

        BrandMaster GetbrandDetails(int brandId);

    }
}
