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
    public class StateMasterRepository : BaseRepository , IStateMasterRepository
    {
        // get all states by 
        public IList<StateMaster> GetAll(int countryId)
        {
            return Query<StateMaster, CountryMaster, StateMaster>(
                "StateMaster_GetAllByCountryId",
                (s, c) =>
                {
                    s.country = c;
                    return s;
                },
                new { countryid = countryId },
                transaction: Transaction,
                commandType: CommandType.StoredProcedure,
                splitOn: "countryid"
              ).ToList();
        }

    }
}
