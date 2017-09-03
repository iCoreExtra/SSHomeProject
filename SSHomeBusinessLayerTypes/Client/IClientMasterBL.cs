using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface IClientMasterBL : IBusinessLayer
    {
        Result<ClientMaster> Add(ClientMaster clientdetails);

        Result<ClientMaster> ClientUpdate(ClientMaster clientdetails);

        IList<ClientMaster> GetClientListAll();

        ClientMaster GetClientDetails(int clientId);
    }
}
