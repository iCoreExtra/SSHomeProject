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
using SSHomeCommon.Constants;

namespace SSHomeRepository
{
    public class StoreMasterRepository : BaseRepository , IStoreMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region IStoreMasterRepository Members
        public Result<StoreMaster> Add(StoreMaster storedetails)
        {
            Result<StoreMaster> result = new Result<StoreMaster>();
            try
            {
                DynamicParameters param = GetStoreRegistrationParameters(storedetails);

                int a = base.Execute("USP_StoreMaster_Insert",
                    param, transaction: Transaction, 
                    commandType: CommandType.StoredProcedure);

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

        public Result<StoreMaster> StoreUpdate(StoreMaster storedetails)
        {
            Result<StoreMaster> result = new Result<StoreMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                if (storedetails.StoreAddressList != null)
                {
                    if (storedetails.StoreAddressList.Count == 1)
                    {
                        param.AddDynamicParams(
                        new
                        {
                            StoreId = storedetails.StoreId,
                            Type = storedetails.Type,
                            Name = storedetails.Name,
                            AddressId = storedetails.AddressId,
                            AddressLine1 = storedetails.StoreAddressList[0].AddressLine1,
                            AddressLine2 = storedetails.StoreAddressList[0].AddressLine2,
                            CityId = storedetails.StoreAddressList[0].CityId,
                            Pincode = storedetails.StoreAddressList[0].Pincode
                        });
                    }
                }

                int a = base.Execute("USP_StoreMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public IList<StoreMaster> GetStoreListAll()
        {
            IList<StoreMaster> list = null;

            try
            {
                list = Query<StoreMaster>(
                                  "USP_StoreMaster_GetAll",
                                  commandType: CommandType.StoredProcedure
                              ).ToList();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return list;
        }

        public StoreMaster GetStoreDetails(int storeId)
        {
            StoreMaster storeDteils = new StoreMaster();

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                StoreId = storeId
            });

            try
            {
                using (var multi = QueryMultiple("USP_GetStoreDetails_ByStoreId", param, Transaction, commandType: CommandType.StoredProcedure))
                {
                    storeDteils = multi.Read<StoreMaster, AddressMaster,StateMaster,StoreMaster> (
                        (sm,am,st) =>
                        {
                            sm.StoreAddressDetails = am;
                            sm.State = st;
                            return sm;
                        }, splitOn: "SplitOn"
                        ).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return storeDteils;
        }

        #endregion

        #region Private Methods
        private DynamicParameters GetStoreRegistrationParameters(StoreMaster storedetails)
        {
            DynamicParameters param = new DynamicParameters();
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add(CommonConstant.ColumnAddressId);
            //dt.Columns.Add(CommonConstant.ColumnAddressLine1);
            //dt.Columns.Add(CommonConstant.ColumnAddressLine2);
            //dt.Columns.Add(CommonConstant.ColumnCityId);
            //dt.Columns.Add(CommonConstant.ColumnPincode);
            //DataRow dr = null;
            //if (storedetails.StoreAddressList != null)
            //{
            //    foreach (var item in storedetails.StoreAddressList)
            //    {
            //        dr = dt.NewRow();
            //        dr[CommonConstant.ColumnAddressId] = item.AddressId;
            //        dr[CommonConstant.ColumnAddressLine1] = item.AddressLine1;
            //        dr[CommonConstant.ColumnAddressLine2] = item.AddressLine2;
            //        dr[CommonConstant.ColumnCityId] = item.CityId;
            //        dr[CommonConstant.ColumnPincode] = item.Pincode;
            //        dt.Rows.Add(dr);
            //    }
            //}

            if (storedetails.StoreAddressList != null)
            {
                if(storedetails.StoreAddressList.Count == 1)
                {
                    param.AddDynamicParams(
                    new
                    {
                      Type = storedetails.Type,
                      Name = storedetails.Name,
                      AddressLine1 = storedetails.StoreAddressList[0].AddressLine1,
                      AddressLine2 = storedetails.StoreAddressList[0].AddressLine2,
                      CityId = storedetails.StoreAddressList[0].CityId,
                      Pincode = storedetails.StoreAddressList[0].Pincode
                    
                      //AddressList = dt.AsTableValuedParameter("AddressMasterType")
                    });
                }
            }

            return param;
        }
        #endregion
    }
}
