using Dapper;
using SSHomeCommon;
using SSHomeCommon.Helpers;
using SSHomeDatalayerCommon;
using SSHomeDataModel;
using SSHomeRepositoryTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepository
{
    public class SpecificationCatalogueRepository:BaseRepository, ISpecificationCatalogueRepository
    {
        #region Constructors

        public SpecificationCatalogueRepository()
        {
        }

        public SpecificationCatalogueRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        public SpecificationCatalogueRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
            if (Transaction != null)
            {
                Connection = transaction.Connection;
            }
        }

        public SpecificationCatalogueRepository(BaseRepository dapProvider)
        {
            if (dapProvider != null)
            {
                Transaction = dapProvider.Transaction;
                Connection = dapProvider.Connection;
            }
        }

        #endregion Constructors

        #region ISpecificationCatalogueRepository Members

        public Result<SpecificationCatalogue> Add(SpecificationCatalogue model)
        {
            Result<SpecificationCatalogue> result = new Result<SpecificationCatalogue>();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.AddDynamicParams(
                    new
                    {
                        Name = model.Name,
                        Code = model.Code,
                        IconPath = model.Iconpath,
                        ValueTypeId = model.ValueTypeId,
                        UserId = model.CreatedBy,
                        status = model.Status,
                        parentid = model.ParentId
                    });

                param.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                base.Execute("USP_SpecificationMaster_Insert", param, transaction: Transaction, commandType: CommandType.StoredProcedure);

                model.Id = param.Get<int>("Id");
                result.Status = ResultStatus.Success;
            }
            catch (Exception ex)
            {
                result.Status = ResultStatus.Failure;
                result.AddModelError(ex);
                SSHomeLogger.LogException(ex);
            }

            result.Model = model;
            return result;

        }
        public IList<SpecificationCatalogue> GetAll()
        {
            return Query<SpecificationCatalogue>(
                "SpecificationMaster_GetAll",
                transaction: Transaction,
                commandType: CommandType.StoredProcedure
                ).ToList();
        }

        public IList<ValueTypeMaster> GetAllValueType()
        {
            return Query<ValueTypeMaster>(
                "ValueTypeMaster_GetAll",
                transaction: Transaction,
                commandType: CommandType.StoredProcedure
                ).ToList();
        }
        #endregion

        #region IPageRepository<BusinessCatalogue> Members
        public IList<SpecificationCatalogue> GetPage(Criteria criteria, out int totalRows)
        {
            IList<SpecificationCatalogue> list = null;
            totalRows = 0;
            var dynamicParams = new DynamicParameters();

            dynamicParams.AddDynamicParams(
                new
                {
                    sortexpression = criteria.ToSortSQL(),
                    pagesize = criteria.PageOption.pagesize,
                    pagenumber = criteria.PageOption.pagenumber
                });

            string paramName = string.Empty;
            foreach (var item in criteria.Parameters)
            {
                paramName = string.Format("@{0}", item.Name);
                dynamicParams.Add(paramName, item.Value);
            }

            using (var multi = QueryMultiple("SpecificationCatalogue_GetAllPaged", dynamicParams, transaction: Transaction,
                commandType: CommandType.StoredProcedure))
            {
                list = multi.Read<SpecificationCatalogue>().ToList();
                totalRows = multi.Read<int>().Single();
            }

            return list;
        }
        #endregion
    }
}
