using Dapper;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeCommon;
using SSHomeCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDatalayerCommon;
using System.Data;

namespace SSHomeRepository
{
    public class BrandMasterRepository : BaseRepository, IBrandMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region IBrandMasterRepository Members
        public IList<BrandMaster> GetAll()
        {
            return Query<BrandMaster>(
                 "BrandMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }

        public Result<BrandMaster> Add(BrandMaster model)
        {
            Result<BrandMaster> result = new Result<BrandMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        Name = model.Name,
                    });


                int a = base.Execute("USP_BrandMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public Result<BrandMaster> UpdateBrandDetails(BrandMaster brandeditdetails)
        {
            Result<BrandMaster> result = new Result<BrandMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        BrandId = brandeditdetails.BrandId,
                        Name = brandeditdetails.Name
                    });


                int a = base.Execute("USP_BrandMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public BrandMaster GetbrandDetails(int brandId)
        {
            BrandMaster brandDetails = new BrandMaster();

            try
            {

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                BrandId = brandId
            });


                brandDetails = Query<BrandMaster>(
                    "USP_GetBrandDetials_ByBrandId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return brandDetails;
        }

        #endregion IBrandMasterRepository Members
    }
}
