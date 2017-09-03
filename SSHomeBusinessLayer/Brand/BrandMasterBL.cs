using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeBusinessLayerTypes;
using SSHomeRepositoryFactory;
using SSHomeRepositoryTypes;
using SSHomeDataModel;
using SSHomeCommon;

namespace SSHomeBusinessLayer
{
    public class BrandMasterBL : BaseBusinessLayer, IBrandMasterBL
    {
        #region class members

        private IBrandMasterRepository _repository;

        #endregion private


        #region Constructor

        public BrandMasterBL()
        {
            _repository = RepositoryFactory.GetRepository<IBrandMasterRepository>();
        }

        #endregion Constructor


        #region IBrandMasterBL member
        public IList<BrandMaster> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<BrandMaster> Add(BrandMaster model)
        {
            return _repository.Add(model);
        }

        public Result<BrandMaster> UpdateBrandDetails(BrandMaster brandeditdetails)
        {
            return _repository.UpdateBrandDetails(brandeditdetails);
        }

        public BrandMaster GetbrandDetails(int brandId)
        {
            return _repository.GetbrandDetails(brandId);
        }

        #endregion
    }
}
