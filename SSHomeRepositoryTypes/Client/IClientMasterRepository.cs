using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IClientMasterRepository : IRepository
    {
        Result<ClientMaster> Add(ClientMaster clientdetails);

        Result<ClientMaster> ClientUpdate(ClientMaster clientdetails);

        IList<ClientMaster> GetClientListAll();

        ClientMaster GetClientDetails(int clientId);
    }
}
