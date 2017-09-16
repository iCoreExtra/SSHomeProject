using BusinessValidation;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSHomeProject.Models
{
    public class SpecificationCatalogueViewModel:BaseModel
    {
        public PagedList.StaticPagedList<SpecificationCatalogue> Specifications { get; set; }
        public string SpecificationCode { get; set; }
        public string SpecificationName { get; set; }
        public int ValueTypeId { get; set; }
        public IList<SelectListItem> ValueType { get; set; }
        public bool IsPartialView { get; set; }
    }
    public class SpecificationCatalogueViewModelForAdd:HierarchyModel,ICatalogue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select parent specification")]
        public int ParentSpecificationId { get; set; }

        [Required(ErrorMessage = "Please enter Specification Code")]
        [StringLength(100)]
        [Display(Name = "Specification Code")]
        public string SpecificationCode { get; set; }

        [Required(ErrorMessage = "Please enter Specification Name")]
        [StringLength(100)]
        [DuplicateProductCategory(ErrorMessage = "Specification with the same name already exist.")]
        [Display(Name = "Specification Name")]
        public string SpecificationName { get; set; }

        [Required(ErrorMessage = "Please Select Vaue Type")]
        [Display(Name = "Value Type")]
        public int ValueTypeId { get; set; }

        public IList<SelectListItem> SpecificationList { get; set; }

        public IList<SelectListItem> ValueTypeList { get; set; }
    }
}