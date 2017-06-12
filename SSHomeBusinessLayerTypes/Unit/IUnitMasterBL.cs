using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayerTypes
{
    public interface IUnitMasterBL : IBusinessLayer
    {
        IList<UnitMaster> GetAll();
    }
}
