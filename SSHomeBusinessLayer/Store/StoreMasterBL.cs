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
    public class StoreMasterBL : BaseBusinessLayer, IStoreMasterBL
    {
        #region class members

        private IStoreMasterRepository _repository;

        #endregion private


        #region Constructor

        public StoreMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IStoreMasterRepository>();
        }

        #endregion Constructor

        #region IStoreMasterBL member

        public Result<StoreMaster> Add(StoreMaster storedetails)
        {
            return _repository.Add(storedetails);
        }

        public IList<StoreMaster> GetStoreListAll()
        {
            return _repository.GetStoreListAll();
        }

        public StoreMaster GetStoreDetails(int storeId)
        {
            return _repository.GetStoreDetails(storeId);
        }

        public Result<StoreMaster> StoreUpdate(StoreMaster stoerdetails)
        {
            return _repository.StoreUpdate(stoerdetails);
        }

        #endregion
    }
}
