using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface ICityMasterBL : IBusinessLayer
    {
        IList<CityMaster> GetAll(int stateId);
    }
}
