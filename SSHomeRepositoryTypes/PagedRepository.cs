using SSHomeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface IPageRepository<T> : IRepository
    {
        IList<T> GetPage(Criteria criteria, out int totalRows);
    }
}
