using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using PRC.API.Hubs;
using PRC.CORE.Model.Media;
using PRC.CORE.Media.Call;
using PRC.CORE.Media.Call.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PRC.API.serviceTest
{
    //public  class ServiceBackCall : BackgroundService
    //{
    //    //private readonly IMediaCall mediaCall;
    //    private readonly IHubContext<SignalR> _mediaCall;

    //    public ServiceBackCall(IHubContext<SignalR> mediaCall)
    //    {
    //        _mediaCall = mediaCall;
    //    }

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            //await mediaCall.EventRegister();
    //            //mediaCall.CallCreated += (ev) =>
    //            //{
    //            //    Console.WriteLine(ev.CallerNumber);
    //            //    Console.WriteLine(ev.DeviceNumber);
    //            //    Console.WriteLine(ev.LoginName);
    //            //    //var CallLoginNumber = ev.LoginName;

    //            //};
    //            await Task.Delay(-1);
    //           // var onCallRemovedEv = new EventCall(loginName, callRef, deviceNumber, callerNumber);
    //           // await _mediaCall.Clients.All.SendAsync("onCallCreated", onCallRemovedEv, stoppingToken);
    //        }

    //    }
    //}

    public sealed class ServiceBackground : BackgroundService
    {
        private readonly IHubContext<SignalR> _messageBrokerHubContext;
        private readonly IMediaCall mediaCall;

        public ServiceBackground(IHubContext<SignalR> messageBrokerHubContext, IMediaCall mediaCall)
        {
            _messageBrokerHubContext = messageBrokerHubContext;
            this.mediaCall = mediaCall;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //await Task.Delay(5000);
                //var eventMessage = new EventMessage($"Id_{ Guid.NewGuid():N}", $"Title_{Guid.NewGuid():N}", DateTime.UtcNow);
                //await _messageBrokerHubContext.Clients.All.SendAsync("onMessageReceived", eventMessage, stoppingToken);

                await mediaCall.EventRegister();
                mediaCall.CallCreated += async (ev) =>

                {
                    string jsonString = JsonSerializer.Serialize(ev);
                    await _messageBrokerHubContext.Clients.All.SendAsync("onMessageReceived", jsonString, stoppingToken);

                    Console.WriteLine(ev.CallerNumber);
                    Console.WriteLine(ev.DeviceNumber);
                    Console.WriteLine(ev.LoginName);
                };
                mediaCall.CallModified += async (ev) =>

                {
                    string jsonString = JsonSerializer.Serialize(ev);
                    await _messageBrokerHubContext.Clients.All.SendAsync("onMessageReceived", jsonString, stoppingToken);

                    Console.WriteLine(ev.CallRef);
                    //Console.WriteLine(ev.ReplacedByCallRef);
                };
                mediaCall.CallRemoved += async (ev) =>

                {
                    string jsonString = JsonSerializer.Serialize(ev);
                    await _messageBrokerHubContext.Clients.All.SendAsync("onMessageReceived", jsonString, stoppingToken);

                    Console.WriteLine(ev.CallRef);
                    Console.WriteLine(ev.LoginName);
                };

                await Task.Delay(-1);


            }
        }
    }

    //public class ServiceBackCall : BackgroundService
    //{
    //    private readonly IMediaCall mediaCall;

    //    public ServiceBackCall(IMediaCall mediaCall)
    //    {
    //        this.mediaCall = mediaCall;
    //    }

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        await mediaCall.EventRegister();
    //        mediaCall.CallCreated += (ev) =>
    //        {
    //            Console.WriteLine(ev.CallerNumber);
    //            Console.WriteLine(ev.DeviceNumber);
    //            Console.WriteLine(ev.LoginName);
    //        };
    //        await Task.Delay(-1);
    //    }
    //}
}
