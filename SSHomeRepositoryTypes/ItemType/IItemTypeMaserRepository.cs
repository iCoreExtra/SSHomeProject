using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IItemTypeMasterRepository : IRepository
    {
        IList<ItemTypeMaster> GetAll();

        Result<ItemTypeMaster> Add(ItemTypeMaster model);

        Result<ItemTypeMaster> UpdateItemTypeDetails(ItemTypeMaster itemtypeeditdetails);

        ItemTypeMaster GetItemTypeDetails(int itemTypeId);
    }
}
