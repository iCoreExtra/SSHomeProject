using SSHomeBusinessLayerTypes;
using SSHomeCommon;
using SSHomeDataModel;
using SSHomeRepositoryFactory;
using SSHomeRepositoryTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayer
{
    public class SpecificationCatalogueBL: ISpecificationCatalogueBL
    {
        #region Class Members
        private ISpecificationCatalogueRepository _repository;

        #endregion

        #region Constructor
        public SpecificationCatalogueBL()
        {
            _repository = RepositoryFactory.GetRepository<ISpecificationCatalogueRepository>();
        }
        #endregion

        #region ISpecificationCatalogueBL Members
        public Result<SpecificationCatalogue> Add(SpecificationCatalogue model)
        {
            return _repository.Add(model);
        }

        public IList<SpecificationCatalogue> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<ValueTypeMaster> GetAllValueType()
        {
            return _repository.GetAllValueType();
        }

        public IList<SpecificationCatalogue> GetPage(Criteria criteria, out int totalRows)
        {
            return _repository.GetPage(criteria, out totalRows);
        }

        #endregion
    }
}
