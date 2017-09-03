using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IStoreMasterRepository : IRepository
    {
        Result<StoreMaster> Add(StoreMaster storedetails);

        Result<StoreMaster> StoreUpdate(StoreMaster stoerdetails);

        IList<StoreMaster> GetStoreListAll();

        StoreMaster GetStoreDetails(int storeId);
    }
}
