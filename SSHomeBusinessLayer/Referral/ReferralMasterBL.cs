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
    public class ReferralMasterBL : BaseBusinessLayer, IReferralMasterBL
    {
        #region class members

        private IReferralMasterRepository _repository;

        #endregion private


        #region Constructor

        public ReferralMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IReferralMasterRepository>();
        }

        #endregion Constructor

        #region IReferralMasterBL member
        public IList<ReferralMaster> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<ReferralMaster> Add(ReferralMaster referralDetails)
        {
            return _repository.Add(referralDetails);
        }

        public Result<ReferralMaster> UpdateReferralDetails(ReferralMaster referraleditdetails)
        {
            return _repository.UpdateReferralDetails(referraleditdetails);
        }

        public ReferralMaster GetReferralDetails(int referralId)
        {
            return _repository.GetReferralDetails(referralId);
        }

        #endregion
    }
}
