using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface IReadyItemMasterRepository : IRepository
    {
        Result<ReadyItemMaster> Add(ReadyItemMaster model);

        Result<ReadyItemMaster> ReadyItemUpdate(ReadyItemMaster model);

        IList<ReadyItemMaster> GetReadyItemListAll();

        ReadyItemMaster GetReadyItemDetails(int readyitemId);
    }
}
