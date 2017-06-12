using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface IRawItemMasterRepository : IRepository
    {
        Result<RawItemMaster> Add(RawItemMaster model);
    }
}
