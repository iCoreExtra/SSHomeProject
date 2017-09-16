using MvcContrib.UI.Grid;
using SSHomeDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class BaseModel : BaseCatalogue
    {
        public GridSortOptions GridSortOptions { get; set; }
    }

    public class HierarchyModel : BaseModel
    {
        // hierarchy information
        //public SqlHierarchyId node { get; set; }
        public string nodestring { get; set; } // node (Primary key)
        public int nodelevel { get; set; }
        public int nodeorder { get; set; } // nodeorder
        // parent information
        public int parentid { get; set; }
        public string parentname { get; set; }
    }
}