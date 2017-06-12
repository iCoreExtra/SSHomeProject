using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using System.Data;

namespace SSHomeRepository
{
    public class BrandMasterRepository : BaseRepository, IBrandMasterRepository
    {
        #region Constructors

        #endregion Constructors

        #region IBrandMasterRepository Members
        public IList<BrandMaster> GetAll()
        {
            return Query<BrandMaster>(
                 "BrandMaster_GetAll",
                 transaction: Transaction,
                 commandType: CommandType.StoredProcedure
               ).ToList();
        }
        #endregion IBrandMasterRepository Members
    }
}
