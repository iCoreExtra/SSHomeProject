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
    public class UnitMasterBL : BaseBusinessLayer, IUnitMasterBL
    {
        #region class members

        private IUnitMasterRepository _repository;

        #endregion private


        #region Constructor

        public UnitMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IUnitMasterRepository>();
        }

        #endregion Constructor

        #region IUnitMasterBL member
        public IList<UnitMaster> GetAll()
        {
            return _repository.GetAll();
        }
        #endregion
    }
}
