using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class ReadyItemMasterViewModel
    {
        public int ReadyItemId { get; set; }

        [Required(ErrorMessage = "Please Enter Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please Enter Description1")]
        public string Description1 { get; set; }

       
        public string Description2 { get; set; }

        public string Description3 { get; set; }

        [Required(ErrorMessage = "Please Enter Material")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Please Enter Color")]
        public string Color { get; set; }

        public Decimal Size { get; set; }

        public Decimal Amount { get; set; }

        //[Required(ErrorMessage = "Please Select Pattern Id")]
        //public int PatternId { get; set; }

        [Required(ErrorMessage = "Please Select Store Id")]
        public int StoreId { get; set; }

        public string StyleCode { get; set; }
    }
}