using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IReferralMasterRepository : IRepository
    {
        IList<ReferralMaster> GetAll();

        Result<ReferralMaster> Add(ReferralMaster referralDetails);

        Result<ReferralMaster> UpdateReferralDetails(ReferralMaster referraleditdetails);

        ReferralMaster GetReferralDetails(int referralId);
    }
}
