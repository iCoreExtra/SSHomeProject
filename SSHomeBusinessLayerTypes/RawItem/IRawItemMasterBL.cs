using SSHomeDataModel;
using SSHomeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SSHomeBusinessLayerTypes
{
    public interface IRawItemMasterBL : IBusinessLayer
    {
        Result<RawItemMaster> Add(RawItemMaster model);

        Result<RawItemMaster> RawItemUpdate(RawItemMaster model);

        IList<RawItemMaster> GetRawItemListAll();

        RawItemMaster GetRawItemDetails(Guid itemId);
    }
}
