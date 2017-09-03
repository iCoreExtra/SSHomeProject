using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface IStoreMasterBL : IBusinessLayer
    {
        Result<StoreMaster> Add(StoreMaster storedetails);

        Result<StoreMaster> StoreUpdate(StoreMaster stoerdetails);

        IList<StoreMaster> GetStoreListAll();

        StoreMaster GetStoreDetails(int storeId);
    }
}
