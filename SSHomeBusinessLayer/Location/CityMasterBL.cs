using SSHomeBusinessLayerTypes;
using SSHomeDataModel;
using SSHomeRepositoryFactory;
using SSHomeRepositoryTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayer
{
    public class CityMasterBL : BaseBusinessLayer , ICityMasterBL
    {
        #region class members

        private ICityMasterRepository _repository;

        #endregion private



        #region Constructor

        public CityMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<ICityMasterRepository>();
        }

        #endregion Constructor

        // get all by countryid
        public IList<CityMaster> GetAll(int stateId)
        {
            return _repository.GetAll(stateId);
        }
    }
}
