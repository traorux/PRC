using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PRC.CORE;
using PRC.CORE.Media.Call;
using PRC.CORE.Media.Call.Events;
using PRC.CORE.Model;
using PRC.CORE.Service;
using PRC.PROCESS.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PRC.PROCESS
{
    public class ServiceBackground : BackgroundService
    {
        private readonly IHubContext<SignalR> _messageHubContext;
        private readonly IMediaCall mediaCall;
        private readonly IMediaService mediaService;
        private readonly object RespLock = new object();

        public ServiceBackground(IHubContext<SignalR> messageHubContext, IMediaCall mediaCall, IServiceProvider service)
        {
            _messageHubContext = messageHubContext;
            this.mediaCall = mediaCall;
            this.mediaService = service.CreateScope().ServiceProvider.GetRequiredService<IMediaService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var tache = mediaCall.EventRegister();
            mediaCall.CallEvent += async (call, contextappels) =>
            {
                Infos infos = new Infos
                {
                    CallRef = call.CallRef,
                    AgentNumber = call.ExtensionNumber,
                    ContextAppels = contextappels.ToString()
                };
                switch (contextappels)
                {
                    case ContextAppels.EmissionAppelSortant:
                        {
                            mediaService.Startoutgoingcall(call);
                            break;
                        };
                    case ContextAppels.AppelSortantSonerie:
                        {
                            call =await mediaService.OutgoingRingingCall(call);
                            break;
                        };
                    case ContextAppels.ReceptionAppelEntrant:
                        {
                            //call = await mediaService.IncomingRingingCall(call);
                            await mediaService.IncomingRingingCall(call);
                            break;
                        };
                    case ContextAppels.AppelSortantCommunication:
                        {
                            await mediaService.OutgoingCallCommunication(call);
                            break;
                        };
                    case ContextAppels.AppelEntrantCoummunucation:
                        {
                            await mediaService.IncomingCallCommunication(call);
                            break;
                        }
                    case ContextAppels.FinDappel:
                        {
                            await mediaService.EndCall(call);
                            break;
                        }
                        //default:
                }


                /*string jsonString = JsonConvert.SerializeObject(infos,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });*/
                await _messageHubContext.Clients.All.SendAsync(infos.ContextAppels, infos.CallRef, infos.AgentNumber, stoppingToken);
                try
                {
                    Console.WriteLine($"---- {call.dateHeure}  {call.CallRef} {call.ExtensionNumber} {call.CustomerNumber}  {call.typeCall} {affich(call.States)} {call.removeParticipant}");
                }
                catch (Exception)
                {
                }
            };
            await tache;
            await Task.Delay(-1);
        }

        private object affich(ICollection<State> states)
        {
            string test = "";
            foreach (var item in states)
            {
                test += " " + item.Status;
            }
            return test;
        }
    }
}
