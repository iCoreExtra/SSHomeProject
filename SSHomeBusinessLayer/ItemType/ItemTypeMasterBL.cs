using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeRepositoryFactory;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayer
{
    public class ItemTypeMasterBL : BaseBusinessLayer , IItemTypeMasterBL
    {
        #region class members

        private IItemTypeMasterRepository _repository;

        #endregion private


        #region Constructor

        public ItemTypeMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IItemTypeMasterRepository>();
        }

        #endregion Constructor


        #region ItemTypeMasterBL member
        public IList<ItemTypeMaster> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<ItemTypeMaster> Add(ItemTypeMaster model)
        {
            return _repository.Add(model);
        }

        public Result<ItemTypeMaster> UpdateItemTypeDetails(ItemTypeMaster itemtypeeditdetails)
        {
            return _repository.UpdateItemTypeDetails(itemtypeeditdetails);
        }

        public ItemTypeMaster GetItemTypeDetails(int itemTypeId)
        {
            return _repository.GetItemTypeDetails(itemTypeId);
        }

        #endregion
    }
}
