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
            var tache = mediaCall.EventRegister();
            mediaCall.CallEvent += (ev) =>
            {
                try
                {
                    Console.WriteLine($"{ev.CallRef} {ev.EventName}  {ev.LoginName} {ev.DeviceNumber} {ev.CallerNumber} {ev.State} {ev.RingingRemote} {ev.Cause}");
                }
                catch (Exception)
                {
                }
            };
            await tache;
            await Task.Delay(-1);
        }
    }
}
