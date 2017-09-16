using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SSHomeBusinessLayerTypes 
{
    public interface IItemTypeMasterBL : IBusinessLayer
    {
        IList<ItemTypeMaster> GetAll();

        Result<ItemTypeMaster> Add(ItemTypeMaster model);

        Result<ItemTypeMaster> UpdateItemTypeDetails(ItemTypeMaster itemtypeeditdetails);

        ItemTypeMaster GetItemTypeDetails(int itemTypeId);
    }
}
