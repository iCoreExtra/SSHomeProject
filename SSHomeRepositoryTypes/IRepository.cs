using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeRepositoryTypes
{
    public interface IRepository
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        IDbTransaction BeginTransaction();

        IDbTransaction BeginTransaction(IsolationLevel isolationLevel);

    }
}
