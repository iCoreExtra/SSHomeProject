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
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSHomeRepository
{
    public class ClientMasterRepository : BaseRepository , IClientMasterRepository
    {
        #region IClientMasterRepository Members
        public Result<ClientMaster> Add(ClientMaster clientdetails)
        {
            Result<ClientMaster> result = new Result<ClientMaster>();
            try
            {
                DynamicParameters param = GetClientParameters(clientdetails);

                int a = base.Execute("USP_ClientMaster_Insert",
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

        public IList<ClientMaster> GetClientListAll()
        {
            IList<ClientMaster> list = null;

            try
            {
                list = Query<ClientMaster>(
                                  "USP_ClientMaster_GetAll",
                                  commandType: CommandType.StoredProcedure
                              ).ToList();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return list;
        }

        public ClientMaster GetClientDetails(int cleintId)
        {
            ClientMaster cleintDetails = new ClientMaster();

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                ClientId = cleintId
            });

            try
            {
                cleintDetails = Query<ClientMaster>(
                                 "USP_GetClientDetails_ByClientId",
                                  param, transaction: Transaction,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return cleintDetails;
        }

        public Result<ClientMaster> ClientUpdate(ClientMaster clientdetails)
        {
            Result<ClientMaster> result = new Result<ClientMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
             
                        param.AddDynamicParams(
                        new
                        {
                            ClientId = clientdetails.ClientId,
                            FirstName = clientdetails.FirstName,
                            LastName = clientdetails.LastName,
                            CompanyName = clientdetails.CompanyName,
                            Number1 = clientdetails.Number1,
                            Number2 = clientdetails.Number2,
                            Email1 = clientdetails.Email1,
                            Email2 = clientdetails.Email2,
                            DateOfBirth = clientdetails.DateOfBirth,
                            Anniversary = clientdetails.Anniversary,
                            ReferralId = clientdetails.ReferralId,
                            StoreId = clientdetails.StoreId,
                            CustomerTypeId = clientdetails.CustomerTypeId,
                            Profession = clientdetails.Profession,
                        });

                int a = base.Execute("USP_ClientMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        #endregion

        #region Private Methods
        private DynamicParameters GetClientParameters(ClientMaster clientdetails)
        {
            DynamicParameters param = new DynamicParameters();

            if (clientdetails.ClientAddressList != null)
            {
                if (clientdetails.ClientAddressList.Count == 1)
                {
                    param.AddDynamicParams(
                    new
                    {
                        FirstName = clientdetails.FirstName,
                        LastName = clientdetails.LastName,
                        CompanyName = clientdetails.CompanyName,
                        Number1 = clientdetails.Number1,
                        Number2 = clientdetails.Number2,
                        Email1 = clientdetails.Email1,
                        Email2 = clientdetails.Email2,
                        DateOfBirth = clientdetails.DateOfBirth,
                        Anniversary = clientdetails.Anniversary,
                        ReferralId = clientdetails.ReferralId,
                        StoreId = clientdetails.StoreId,
                        CustomerTypeId = clientdetails.CustomerTypeId,
                        Profession  = clientdetails.Profession,

                        AddressLine1 = clientdetails.ClientAddressList[0].AddressLine1,
                        AddressLine2 = clientdetails.ClientAddressList[0].AddressLine2,
                        CityId = clientdetails.ClientAddressList[0].CityId,
                        Pincode = clientdetails.ClientAddressList[0].Pincode
                    });
                }
            }

            return param;
        }
        #endregion
    }
}
