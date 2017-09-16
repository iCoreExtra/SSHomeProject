using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface IUnitMasterRepository : IRepository
    {
        IList<UnitMaster> GetAll();

        Result<UnitMaster> Add(UnitMaster unitDetails);

        Result<UnitMaster> UpdateUnitDetails(UnitMaster uniteditdetails);

        UnitMaster GetunitDetails(int unitId);
    }
}
