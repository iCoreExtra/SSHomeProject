using System;
using System.Data;
using System.Linq;
using SSHomeCommon.Helpers;
using SSHomeCommon;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeDatalayerCommon;
using Dapper;
using System.Collections.Generic;

namespace SSHomeRepository
{
    public class EmployeeMasterRepository : BaseRepository, IEmployeeMasterRepository
    {
        public Result<EmployeeMaster> Create(EmployeeMaster employeeMaster)
        {
            Result<EmployeeMaster> result = new Result<EmployeeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(new
                {
                    UserName = employeeMaster.UserName,
                    Password = employeeMaster.Password,
                    FirstName = employeeMaster.FirstName,
                    LastName = employeeMaster.LastName,
                    Mobile = employeeMaster.Mobile,
                    Phone2 = employeeMaster.Phone2,
                    Email = employeeMaster.Email2,
                    DateOfBirth = employeeMaster.DateOfBirth,
                    DesignationId = employeeMaster.DesignationId,
                    StoreId = employeeMaster.StoreId,
                    CreatedBy = employeeMaster.CreatedBy
                });

                base.Execute("USP_EmployeeMaster_Insert", param, Transaction, commandType: CommandType.StoredProcedure);
                result.Status = ResultStatus.Success;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                result.Status = ResultStatus.Failure;
                result.Model = employeeMaster;
            }
            return result;
        }

        public List<EmployeeMaster> FindByName(string userName)
        {
            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(new { UserName = userName });
            return Query<EmployeeMaster>("USP_EmployeeMaster_GetByUserName", param, Transaction, commandType: CommandType.StoredProcedure).ToList();
        }

        public EmployeeMaster FindByEmail(string email)
        {
            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(new { Email = email });
            return Query<EmployeeMaster>("USP_EmployeeMaster_GetByEmail", param, Transaction, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
