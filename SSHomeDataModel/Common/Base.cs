using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;

namespace SSHomeDataModel
{
    public interface ICatalogue
    {
    }

    public class BaseCatalogue : ICatalogue
    {
        public DateTime CreatedOn { get; set; } // createdon
        public Guid CreatedBy { get; set; } // createdby
        public Guid UpdatedBy { get; set; } // updateby
        public DateTime UpdatedOn { get; set; } // updateon
        public bool Status { get; set; } // status
        public int? ErrorCode { get; set; } //error code
        public string ErrorDescription { get; set; } //error description
    }

    public class HierarchyCatalgoue : BaseCatalogue
    {
        // hierarchy information
        public SqlHierarchyId? Node { get; set; }
        public string NodeString { get; set; } // node (Primary key)
        public int NodeLevel { get; set; }
        public int NodeOrder { get; set; } // nodeorder

        // parent information
        public int ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
