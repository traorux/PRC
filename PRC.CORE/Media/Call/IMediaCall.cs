using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call
{
    public interface IMediaCall
    {
        Task EventRegister();
        Task<bool> MakeCall(string AgentNumber, string CustomNumber);
        event Action<string> ReceivedCall;
    }
}
