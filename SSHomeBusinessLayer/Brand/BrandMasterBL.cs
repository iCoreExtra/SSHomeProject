using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeRepositoryFactory;
using SSHomeRepositoryTypes;
using SSHomeDataModel;

namespace SSHomeBusinessLayer
{
    public class BrandMasterBL : BaseBusinessLayer, IBrandMasterBL
    {
        #region class members

        private IBrandMasterRepository _repository;

        #endregion private


        #region Constructor

        public BrandMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IBrandMasterRepository>();
        }

        #endregion Constructor


        #region IBrandMasterBL member
        public IList<BrandMaster> GetAll()
        {
            return _repository.GetAll();
        }
        #endregion
    }
}
