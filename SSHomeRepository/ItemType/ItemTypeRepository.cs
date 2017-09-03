using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using System.Data;
using SSHomeCommon;
using Dapper;
using SSHomeDatalayerCommon;
using SSHomeCommon.Helpers;

namespace SSHomeRepository
{
    public class ItemTypeRepository : BaseRepository , IItemTypeMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region IItemTypeMasterRepository Members
        public IList<ItemTypeMaster> GetAll()
        {
            return Query<ItemTypeMaster>(
                 "ItemTypeMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }

        public Result<ItemTypeMaster> Add(ItemTypeMaster model)
        {
            Result<ItemTypeMaster> result = new Result<ItemTypeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        Name = model.Name,
                    });


                int a = base.Execute("USP_ItemTypeMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public Result<ItemTypeMaster> UpdateItemTypeDetails(ItemTypeMaster itemtypeeditdetails)
        {
            Result<ItemTypeMaster> result = new Result<ItemTypeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        ItemTypeId = itemtypeeditdetails.ItemTypeId,
                        Name = itemtypeeditdetails.Name
                    });

                int a = base.Execute("USP_ItemTypeMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public ItemTypeMaster GetItemTypeDetails(int itemTypeId)
        {
            ItemTypeMaster itemTypeDetails = new ItemTypeMaster();

            try
            {

                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                new
                {
                    ItemTypeId = itemTypeId
                });


                itemTypeDetails = Query<ItemTypeMaster>(
                    "USP_GetItemTypeDetials_ByItemTypeId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return itemTypeDetails;
        }

        #endregion IItemTypeMasterRepository Members
    }
}
