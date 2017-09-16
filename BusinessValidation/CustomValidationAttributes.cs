using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using SSHomeRepositoryTypes;
using SSHomeRepositoryFactory;
using SSHomeDataModel;
using SSHomeCommon.Constants;
using SSHomeCommon.Helpers;

namespace BusinessValidation
{
    public class CustomValidationAttributes
    {

    }

    public class DuplicateProductCategory : ValidationAttribute
    {
        #region Private members

        private ISpecificationCatalogueRepository _service;

        #endregion

        #region Constructor

        public DuplicateProductCategory()
        {
            _service = RepositoryFactory.GetRepository<ISpecificationCatalogueRepository>();
        }

        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isUnique = false;

            int parentId = Convert.ToInt16(validationContext.ObjectType.GetProperty("ParentSpecificationId")
                .GetValue(validationContext.ObjectInstance, null));

            int id = Convert.ToInt16(validationContext.ObjectType.GetProperty("Id").GetValue(validationContext.ObjectInstance, null));

            List<SpecificationCatalogue> lstSpecificationCatalogue = null;

            // Check if Category exist in cache
            bool isAvailableInCache = CacheHelper.TryGet(CommonConstant.CacheSpecification, out lstSpecificationCatalogue);

            if (!isAvailableInCache)
            {
                // Since category data is not in cache make database call to get category
                lstSpecificationCatalogue = _service.GetAll().ToList();

                // Save Category in Cache for future reference
                CacheHelper.Add(CommonConstant.CacheSpecification, lstSpecificationCatalogue);
            }

            if (lstSpecificationCatalogue != null && lstSpecificationCatalogue.Count > 0)
            {
                isUnique = !lstSpecificationCatalogue.Any(p => p.ParentId == parentId && p.Id != id &&
                        string.Equals(p.Name, Convert.ToString(value), StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = true;
            }

            if (isUnique)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Specification with the same name already exist under selected parent Specification.");
            }
        }
    }
}
