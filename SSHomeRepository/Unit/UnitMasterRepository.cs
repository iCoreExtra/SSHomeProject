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
    public class UnitMasterRepository : BaseRepository, IUnitMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region  IUnitMasterRepository Members
        public IList<UnitMaster> GetAll()
        {
            return Query<UnitMaster>(
                 "UnitMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }


        public Result<UnitMaster> Add(UnitMaster unitDetails)
        {
            Result<UnitMaster> result = new Result<UnitMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        Unit = unitDetails.Unit,
                    });

                int a = base.Execute("USP_UnitMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public Result<UnitMaster> UpdateUnitDetails(UnitMaster uniteditdetails)
        {
            Result<UnitMaster> result = new Result<UnitMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        UnitId = uniteditdetails.UnitId,
                        Unit = uniteditdetails.Unit
                    });


                int a = base.Execute("USP_UnitMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public UnitMaster GetunitDetails(int unitId)
        {
            UnitMaster unitDetails = new UnitMaster();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                new
                {
                    UnitId = unitId
                });


                unitDetails = Query<UnitMaster>(
                    "USP_GetUnitDetials_ByUnitId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return unitDetails;
        }
        #endregion

    }
}
