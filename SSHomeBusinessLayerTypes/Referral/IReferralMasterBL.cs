using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface IReferralMasterBL : IBusinessLayer
    {
        IList<ReferralMaster> GetAll();

        Result<ReferralMaster> Add(ReferralMaster referralDetails);

        Result<ReferralMaster> UpdateReferralDetails(ReferralMaster referraleditdetails);

        ReferralMaster GetReferralDetails(int referralId);
    }
}
