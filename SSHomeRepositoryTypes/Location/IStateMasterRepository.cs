using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface IStateMasterRepository : IRepository
    {
         IList<StateMaster> GetAll(int countryId);
    }
}
