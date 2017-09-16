using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface ISpecificationCatalogueBL:IBusinessLayer,IPageBL<SpecificationCatalogue>
    {
        Result<SpecificationCatalogue> Add(SpecificationCatalogue model);

        IList<SpecificationCatalogue> GetAll();

        IList<ValueTypeMaster> GetAllValueType();
    }
}
