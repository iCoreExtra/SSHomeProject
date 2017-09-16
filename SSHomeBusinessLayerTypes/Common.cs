using SSHomeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeBusinessLayerTypes
{
    public interface ICommonBL
    {
    }

    public interface IBusinessLayer
    {
    }

    public interface IPageBL<T>
    {
        IList<T> GetPage(Criteria criteria, out int totalRows);

        //IList<T> GetPagewithParameter(string Str, Criteria criteria, out int totalRows);
    }
}
