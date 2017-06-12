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
        #endregion

    }
}
