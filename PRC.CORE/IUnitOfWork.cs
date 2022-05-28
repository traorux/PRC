using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        ICallRepository Calls { get; }
        IDataCustomRepository dataCustoms { get; }
        IRequestRepository Requests { get; }
        Task<int> CommitAsync();
    }
}
