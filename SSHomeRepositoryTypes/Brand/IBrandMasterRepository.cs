using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IBrandMasterRepository : IRepository
    {
        IList<BrandMaster> GetAll();

        Result<BrandMaster> Add(BrandMaster model);

        Result<BrandMaster> UpdateBrandDetails(BrandMaster brandeditdetails);

        BrandMaster GetbrandDetails(int brandId);
    }
}
