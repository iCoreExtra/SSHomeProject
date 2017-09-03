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
    public class CityMasterRepository : BaseRepository, ICityMasterRepository
    {
        #region ICityMasterRepository Members     

        public IList<CityMaster> GetAll(int stateId)
        {
            return Query<CityMaster, StateMaster, CountryMaster, CityMaster>(
                "CityMaster_GetAllByStateId",
                (c, s, co) =>
                {
                    c.state = s;
                    s.country = co;
                    return c;
                },
                new { stateid = stateId },
                transaction: Transaction,
                commandType: CommandType.StoredProcedure,
                splitOn: "StateId,CountryId"
              ).ToList();
        }

        #endregion
    }
}
