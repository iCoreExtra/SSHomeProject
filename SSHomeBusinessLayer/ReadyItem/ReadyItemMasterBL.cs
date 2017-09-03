using SSHomeBusinessLayerTypes;
using SSHomeCommon;
using SSHomeDataModel;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayer
{
    public class ReadyItemMasterBL : BaseBusinessLayer, IReadyItemMasterBL
    {
        #region class members

        private IReadyItemMasterRepository _repository;

        #endregion private

        #region Constructor
        public ReadyItemMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IReadyItemMasterRepository>();
        }

        #endregion Constructor

        #region IReadyItemMasterBL member
        public Result<ReadyItemMaster> Add(ReadyItemMaster model)
        {
            return _repository.Add(model);
        }

        public Result<ReadyItemMaster> ReadyItemUpdate(ReadyItemMaster model)
        {
            return _repository.ReadyItemUpdate(model);
        }


        public IList<ReadyItemMaster> GetReadyItemListAll()
        {
            return _repository.GetReadyItemListAll();
        }

        public ReadyItemMaster GetReadyItemDetails(int readyitemId)
        {
            return _repository.GetReadyItemDetails(readyitemId);
        }
        #endregion
    }
}
