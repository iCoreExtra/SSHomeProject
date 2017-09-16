using SSHomeCommon;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface ISpecificationCatalogueRepository : IPageRepository<SpecificationCatalogue>
    {

        Result<SpecificationCatalogue> Add(SpecificationCatalogue model);
        // get all
        IList<SpecificationCatalogue> GetAll();

        IList<ValueTypeMaster> GetAllValueType();
    }
}
