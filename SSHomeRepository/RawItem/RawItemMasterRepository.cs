using Dapper;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepository
{
    public class RawItemMasterRepository : BaseRepository, IRawItemMasterRepository
    {
        #region Constructors
         public RawItemMasterRepository()
         {

         }
        #endregion

        #region  IRawItemMasterRepository Members
        public Result<RawItemMaster> Add(RawItemMaster model)
        {
            Result<RawItemMaster> result = new Result<RawItemMaster>();
            return result;
        }
        #endregion
    }
}
