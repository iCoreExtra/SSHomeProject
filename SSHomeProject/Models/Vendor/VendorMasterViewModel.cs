using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;

namespace SSHomeProject.Models
{
    public class VendorMasterViewModel
    {
        public int VendorId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Number 1")]
        [Required(ErrorMessage = "Contact Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Contact1 { get; set; }

        [Display(Name = "Contact Number 2")]
        public string Contact2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter email address")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9,!#\$%&\*\+/=\?\^_\{\|}~-]+(\.[a-z0-9,!#\$%&\*\+/=\?\^_\{\|}~-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,})$", ErrorMessage = "InValid Email format")]
        [Display(Name = "Email 1")]
        public string Email1 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter email address")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9,!#\$%&\*\+/=\?\^_\{\|}~-]+(\.[a-z0-9,!#\$%&\*\+/=\?\^_\{\|}~-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,})$", ErrorMessage = "InValid Email format")]
        [Display(Name = "Email 2")]
        public string Email2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter GST No")]
        [StringLength(15, ErrorMessage = "Cannot be greater than 15 characters")]
        [Display(Name = "GST No")]
        public string GSTNo { get; set; }

        public Guid AddressId { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(145, ErrorMessage = "Please enter some data in Address Line 1")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Display(Name = "Select State")]
        [Range(0, 100, ErrorMessage = "Please Select State")]
        public int StateId { get; set; }

        [Display(Name = "Select City")]
        [Range(0, 100, ErrorMessage = "Please Select City")]
        public int CityId { get; set; }

        [Display(Name = "Pincode")]
        [MinLength(3, ErrorMessage = "Please enter minimum 3 digits for Pincode")]
        public string Pincode { get; set; }

        public PageMode Mode { get; set; }
    }

    public class VendorListViewModel
    {
        public List<VendorMaster> VendorList { get; set; }
    }
}