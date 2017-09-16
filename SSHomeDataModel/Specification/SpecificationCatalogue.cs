using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class SpecificationCatalogue:HierarchyCatalgoue
    {
        public int Id { get; set; }

        public string Code { get; set; } // code

        public string Name { get; set; } // name

        public string Iconpath { get; set; }// product image

        public int ValueTypeId { get; set; } // description

    }
}
