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
    public class VendorMasterRepository : BaseRepository , IVendorMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region IVendorMasterRepository Members
        public Result<VendorMaster> Add(VendorMaster vendordetails)
        {
            Result<VendorMaster> result = new Result<VendorMaster>();
            try
            {
                DynamicParameters param = GetVendorRegistrationParameters(vendordetails);

                int a = base.Execute("USP_VendorMaster_Insert",
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

        public IList<VendorMaster> GetVendorListAll()
        {
            IList<VendorMaster> list = null;

            try
            {
                list = Query<VendorMaster>(
                                  "USP_VendorMaster_GetAll",
                                  commandType: CommandType.StoredProcedure
                              ).ToList();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return list;
        }

        public VendorMaster GetVendorDetails(int vendorId)
        {
            VendorMaster vendorDetails = new VendorMaster();

            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(
            new
            {
                vendorId = vendorId
            });

            try
            {
                using (var multi = QueryMultiple("USP_GetVendorDetails_ByVendorId", param, Transaction, commandType: CommandType.StoredProcedure))
                {
                    vendorDetails = multi.Read<VendorMaster, AddressMaster, StateMaster, VendorMaster>(
                        (sm, am, st) =>
                        {
                            sm.VendorAddressDetails = am;
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

            return vendorDetails;
        }

        public Result<VendorMaster> VendorUpdate(VendorMaster vendordetails)
        {
            Result<VendorMaster> result = new Result<VendorMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                if (vendordetails.VendorAddressList != null)
                {
                    if (vendordetails.VendorAddressList.Count == 1)
                    {
                        param.AddDynamicParams(
                        new
                        {
                            VendorId = vendordetails.VendorId,
                            FirstName = vendordetails.FirstName,
                            LastName = vendordetails.LastName,
                            CompanyName = vendordetails.CompanyName,
                            Contact1 = vendordetails.Contact1,
                            Contact2 = vendordetails.Contact2,
                            Email1 = vendordetails.Email1,
                            Email2 = vendordetails.Email2,
                            GSTNo = vendordetails.GSTNo,
                            AddressId = vendordetails.AddressId,
                            AddressLine1 = vendordetails.VendorAddressList[0].AddressLine1,
                            AddressLine2 = vendordetails.VendorAddressList[0].AddressLine2,
                            CityId = vendordetails.VendorAddressList[0].CityId,
                            Pincode = vendordetails.VendorAddressList[0].Pincode
                        });
                    }
                }

                int a = base.Execute("USP_VendorMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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
        private DynamicParameters GetVendorRegistrationParameters(VendorMaster vendordetails)
        {
            DynamicParameters param = new DynamicParameters();

            if (vendordetails.VendorAddressList != null)
            {
                if (vendordetails.VendorAddressList.Count == 1)
                {
                    param.AddDynamicParams(
                    new
                    {
                        FirstName = vendordetails.FirstName,
                        LastName = vendordetails.LastName,
                        CompanyName = vendordetails.CompanyName,
                        Contact1 = vendordetails.Contact1,
                        Contact2 = vendordetails.Contact2,
                        Email1 = vendordetails.Email1,
                        Email2 = vendordetails.Email2,
                        GSTNo  = vendordetails.GSTNo,

                        AddressLine1 = vendordetails.VendorAddressList[0].AddressLine1,
                        AddressLine2 = vendordetails.VendorAddressList[0].AddressLine2,
                        CityId = vendordetails.VendorAddressList[0].CityId,
                        Pincode = vendordetails.VendorAddressList[0].Pincode
                    });
                }
            }

            return param;
        }
        #endregion
    }
}
