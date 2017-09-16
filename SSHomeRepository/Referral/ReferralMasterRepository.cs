using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeCommon;
using System.Data;
using SSHomeDatalayerCommon;
using SSHomeCommon.Helpers;

namespace SSHomeRepository
{
    public class ReferralMasterRepository : BaseRepository, IReferralMasterRepository
    {
        #region IReferralMasterRepository Members
        public IList<ReferralMaster> GetAll()
        {
            return Query<ReferralMaster>(
                 "USP_ReferralMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }


        public Result<ReferralMaster> Add(ReferralMaster referralDetails)
        {
            Result<ReferralMaster> result = new Result<ReferralMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        Source = referralDetails.Source,
                    });

                int a = base.Execute("USP_ReferralMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

                result.Status = ResultStatus.Success;
            }
            catch (Exception ex)
            {
                result.Status = ResultStatus.Failure;
                result.AddModelError(ex);
                SSHomeLogger.LogException(ex);
            }

            return result;
        }

        public Result<ReferralMaster> UpdateReferralDetails(ReferralMaster referraleditdetails)
        {
            Result<ReferralMaster> result = new Result<ReferralMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ReferralId = referraleditdetails.ReferralId,
                        Source = referraleditdetails.Source
                    });


                int a = base.Execute("USP_ReferralMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

                result.Status = ResultStatus.Success;
            }
            catch (Exception ex)
            {
                result.Status = ResultStatus.Failure;
                result.AddModelError(ex);
                SSHomeLogger.LogException(ex);
            }

            return result;
        }

        public ReferralMaster GetReferralDetails(int referralId)
        {
            ReferralMaster referralDetails = new ReferralMaster();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                new
                {
                    ReferralId = referralId
                });


                referralDetails = Query<ReferralMaster>(
                    "USP_GetReferralDetials_ByReferralId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return referralDetails;
        }
        #endregion
    }
}
