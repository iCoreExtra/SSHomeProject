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
    public class ReadyItemMasterRepository : BaseRepository , IReadyItemMasterRepository
    {
        #region  IReadyItemMasterRepository Members
        public Result<ReadyItemMaster> Add(ReadyItemMaster model)
        {
            Result<ReadyItemMaster> result = new Result<ReadyItemMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ItemName = model.ItemName,
                        Description1 = model.Description1,
                        Description2 = model.Description2,
                        Description3 = model.Description3,
                        Material = model.Material,
                        Color = model.Color,
                        Size = model.Size,
                        Amount = model.Amount,
                        StoreId = model.StoreId,
                        StyleCode = model.StyleCode
                    });


                int a = base.Execute("USP_ReadyItemMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public Result<ReadyItemMaster> ReadyItemUpdate(ReadyItemMaster model)
        {
            Result<ReadyItemMaster> result = new Result<ReadyItemMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ItemName = model.ItemName,
                        Description1 = model.Description1,
                        Description2 = model.Description2,
                        Description3 = model.Description3,
                        Material = model.Material,
                        Color = model.Color,
                        Size = model.Size,
                        Amount = model.Amount,
                        StoreId = model.StoreId,
                        StyleCode = model.StyleCode
                    });


                int a = base.Execute("USP_ReadyItemMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public IList<ReadyItemMaster> GetReadyItemListAll()
        {
            IList<ReadyItemMaster> list = null;

            try
            {
                list = Query<ReadyItemMaster>(
                                  "USP_ReadyItemMaster_GetAll",
                                  commandType: CommandType.StoredProcedure
                              ).ToList();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return list;
        }

        public ReadyItemMaster GetReadyItemDetails(int readyitemId)
        {
            ReadyItemMaster readyItemDteils = new ReadyItemMaster();

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                ReadyItemId = readyitemId
            });

            try
            {
                readyItemDteils = Query<ReadyItemMaster>(
                    "USP_GetReadyItemMasterDetails_ByReadyItemId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return readyItemDteils;
        }

        #endregion
    }
}
