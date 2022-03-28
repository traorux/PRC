using Microsoft.Extensions.Hosting;
using PRC.CORE.Media.Call;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRC.PROCESS
{
    public class ServiceBackground : BackgroundService
    {
        private readonly IMediaCall mediaCall;

        public ServiceBackground(IMediaCall mediaCall)
        {
            this.mediaCall = mediaCall;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await mediaCall.EventRegister();
            mediaCall.ReceivedCall += (s) => 
            {
                Console.WriteLine(s);
            };
            await Task.Delay(-1);
        }
    }
}
