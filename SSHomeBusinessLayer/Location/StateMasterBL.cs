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
    public class StateMasterBL : BaseBusinessLayer , IStateMasterBL
    {
        #region class members

        private IStateMasterRepository _repository;

        #endregion private



        #region Constructor

        public StateMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IStateMasterRepository>();
        }

        #endregion Constructor

        // get all by countryid
        public IList<StateMaster> GetAll(int countryId)
        {
            return _repository.GetAll(countryId);
        }
    }
}
