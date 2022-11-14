using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetAllRequest();
        Task<Request> GetRequestById(string IdRequest);
        Task<Request> AddRequest(Request request);
        Task<Request> UpdateRequest(Request request);
        Task DeleteRequest(Request request);
    }
}
