using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface IStateMasterBL : IBusinessLayer 
    {
        IList<StateMaster> GetAll(int countryId);
    }
}
