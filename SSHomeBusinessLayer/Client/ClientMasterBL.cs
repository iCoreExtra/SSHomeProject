using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeCommon;
using SSHomeDataModel;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;

namespace SSHomeBusinessLayer
{
    public class ClientMasterBL : BaseBusinessLayer , IClientMasterBL
    {
        #region class members

        private IClientMasterRepository _repository;

        #endregion private


        #region Constructor

        public ClientMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IClientMasterRepository>();
        }

        #endregion Constructor

        #region IClientMasterBL member

        public Result<ClientMaster> Add(ClientMaster clientdetails)
        {
            return _repository.Add(clientdetails);
        }

        public IList<ClientMaster> GetClientListAll()
        {
            return _repository.GetClientListAll();
        }

        public ClientMaster GetClientDetails(int clientId)
        {
            return _repository.GetClientDetails(clientId);
        }

        public Result<ClientMaster> ClientUpdate(ClientMaster clientdetails)
        {
            return _repository.ClientUpdate(clientdetails);
        }

        #endregion
    }
}
