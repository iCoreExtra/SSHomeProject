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
    public class RawItemMasterBL : BaseBusinessLayer, IRawItemMasterBL
    {
        #region class members

        private IRawItemMasterRepository _repository;

        #endregion private

        #region Constructor
        public RawItemMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IRawItemMasterRepository>();
        }

        #endregion Constructor

        #region IRawItemMasterBL member
        public Result<RawItemMaster> Add(RawItemMaster model)
        {
            return _repository.Add(model);
        }
        #endregion
    }
}
