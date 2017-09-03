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
    public class RawItemMasterRepository : BaseRepository, IRawItemMasterRepository
    {
        #region Constructors
         public RawItemMasterRepository()
         {

         }
        #endregion

        #region  IRawItemMasterRepository Members
        public Result<RawItemMaster> Add(RawItemMaster model)
        {
            Result<RawItemMaster> result = new Result<RawItemMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ItemName = model.ItemName,
                        Material = model.Material,
                        Color = model.Color,
                        Description1 = model.Description1,
                        Description2 = model.Description2,
                        Description3 = model.Description3,
                        Description4 = model.Description4,
                        Description5 = model.Description5,
                        UnitId = model.UnitId,
                        BrandId = model.BrandId,
                        ItemTypeId = model.ItemTypeId
                    });


                int a = base.Execute("USP_RawItemMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

         public Result<RawItemMaster> RawItemUpdate(RawItemMaster model)
        {
            Result<RawItemMaster> result = new Result<RawItemMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ItemId = model.ItemId,
                        ItemName = model.ItemName,
                        Material = model.Material,
                        Color = model.Color,
                        Description1 = model.Description1,
                        Description2 = model.Description2,
                        Description3 = model.Description3,
                        Description4 = model.Description4,
                        Description5 = model.Description5,
                        UnitId = model.UnitId,
                        BrandId = model.BrandId,
                        ItemTypeId = model.ItemTypeId
                    });


                int a = base.Execute("USP_RawItemMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public IList<RawItemMaster> GetRawItemListAll()
        {
            IList<RawItemMaster> list = null;

            try
            {
                list = Query<RawItemMaster>(
                                  "USP_RawItemMaster_GetAll",
                                  commandType: CommandType.StoredProcedure
                              ).ToList();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return list;
        }

        public RawItemMaster GetRawItemDetails(Guid itemId)
        {
            RawItemMaster rawItemDteils = new RawItemMaster();

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                ItemId = itemId
            });

            try
            {
                rawItemDteils = Query<RawItemMaster>(
                    "USP_GetRawItemDetials_ByItemId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return rawItemDteils;
        }

        #endregion
    }
}
