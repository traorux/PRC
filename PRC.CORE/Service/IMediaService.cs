using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Service
{
    public interface IMediaService
    {
        // Call Services
         Call Startoutgoingcall(Call call);
         Task<Call> OutgoingRingingCall(Call call);
         Task<Call> IncomingRingingCall(Call call);
         Task<Call> OutgoingCallCommunication(Call call);
         Task<Call> IncomingCallCommunication(Call call);
         Task<Call> EndCall(Call call);
         Task<bool> MakeOutgoingCall(Call call);
         Task<bool> DropeCall();

         // Extension services
         Task<IEnumerable<Extension>> GetExtensionsList();
        Task<bool> CreateExtension(Extension extension);
        void DeleteExtension(Extension extension);
        Task<bool> UpdateExtension(Extension extension);




        //Customer sersvices
        Task<bool> CreateCustomer(Customer customer);
         Task<bool> UpdateCustomer(Customer customer);
         Task<Customer> SearchCustomer(string customerNumber);
         Task<IEnumerable<Call>> GetCallsList();
         Task<IEnumerable<Call>> GetHistsList(string customerNumber);
        Task<ICollection<History>> GetHistories(string customerNumber);
        Task<Call> GetCallInfos(string CallRef);

        Task<Request> CreateRequest(Request request);


    }
}
