using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface ICityMasterRepository : IRepository
    {
        IList<CityMaster> GetAll(int stateId);
    }
}
