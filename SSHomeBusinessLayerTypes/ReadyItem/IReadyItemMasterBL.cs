using SSHomeDataModel;
using SSHomeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface IReadyItemMasterBL : IBusinessLayer
    {
        Result<ReadyItemMaster> Add(ReadyItemMaster model);

        Result<ReadyItemMaster> ReadyItemUpdate(ReadyItemMaster model);

        IList<ReadyItemMaster> GetReadyItemListAll();

        ReadyItemMaster GetReadyItemDetails(int readyitemId);
    }
}
