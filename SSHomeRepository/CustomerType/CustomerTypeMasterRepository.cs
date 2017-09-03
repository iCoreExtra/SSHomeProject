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
    public class CustomerTypeMasterRepository : BaseRepository ,ICustomerTypeMasterRepository
    {
        #region ICustomerTypeRepository Members
        public IList<CustomerTypeMaster> GetAll()
        {
            return Query<CustomerTypeMaster>(
                 "USP_CustomerTypeMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }


        public Result<CustomerTypeMaster> Add(CustomerTypeMaster customerTypeDetails)
        {
            Result<CustomerTypeMaster> result = new Result<CustomerTypeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        CustomerType = customerTypeDetails.CustomerType,
                    });

                int a = base.Execute("USP_CustomerTypeMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public Result<CustomerTypeMaster> UpdateCustomerTypeDetails(CustomerTypeMaster customertypeeditdetails)
        {
            Result<CustomerTypeMaster> result = new Result<CustomerTypeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        //UserId = "00000000-0000-0000-0000-000000000000",
                        CustomerTypeId = customertypeeditdetails.CustomerTypeId,
                        CustomerType = customertypeeditdetails.CustomerType
                    });

                int a = base.Execute("USP_CustomerTypeMaster_Update", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

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

        public CustomerTypeMaster GetCustomerTypeDetails(int customerTypeId)
        {
            CustomerTypeMaster customerTypeDetails = new CustomerTypeMaster();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                new
                {
                    CustomerTypeId = customerTypeId
                });


                customerTypeDetails = Query<CustomerTypeMaster>(
                    "USP_GetCustomerTypeDetials_ByCustomerTypeId",
                    param: param,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return customerTypeDetails;
        }
        #endregion
    }
}
