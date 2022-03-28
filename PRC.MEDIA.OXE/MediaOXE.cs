using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using o2g;
using PRC.CORE.Media.Call;
using PRC.HELPER.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.MEDIA.OXE
{
    public class MediaOXE : IMediaCall
    {
        private string myLoginName = "oxe769";
        private string myPassword = "0000";
        private O2G.Application myApplication;
        private ITelephony telephony;
        private bool Connected = false;
        private readonly string Host_o2G;
        private readonly ILogger<MediaOXE> logger;

        public event Action<string> ReceivedCall;

        public MediaOXE(ILogger<MediaOXE> logger, IConfiguration Config)
        {
            Host_o2G = Config.GetSection("BaseURL").GetSection("O2G_HOST").Value;
            this.logger = logger;
            //EventRegister().Wait();
        }
        public async Task EventRegister()
        {
            Connected = false;
            try
            {
                if (myApplication is null)
                {
                    myApplication = new("ApplicationName");

                }
                await myApplication.ShutdownAsync();
                o2g.Types.Host host = new o2g.Types.Host();
                host.PrivateAddress = Host_o2G;

                myApplication.SetHost(host);

                await myApplication.LoginAsync(myLoginName, myPassword);

                Subscription subscription = Subscription.Builder
                    .AddTelephonyEvents()
                    .Build();

                myApplication.ChannelInformation += (source, ev) =>
                {
                    logger.LogDebug($"Eventing channel is established host {Host_o2G}.");
                    //Connected = true;
                    telephony = myApplication.TelephonyService;

                    if (telephony is not null)
                    {
                        Connected = true;
                        telephony.CallCreated += (source, ev) =>
                        {
                            ReceivedCall?.Invoke(ev.Event.Initiator);
                        };
                        telephony.CallModified += (source, ev) =>
                        {
                            ReceivedCall?.Invoke(ev.Event.LoginName);
                        };
                        telephony.CallRemoved += (source, ev) =>
                        {
                            ReceivedCall?.Invoke(ev.Event.EventName);
                        };

                        logger.LogDebug($"O2G is connected and Event is established host {Host_o2G}.");
                    }
                };
                
                // Suscribe to events using the built subscription
                await myApplication.SubscribeAsync(subscription);
            }
            catch (Exception ex)
            {
                Connected = false;
                logger.LogError(ex, $"Error to connect host {Host_o2G}");
            }
        }
        public async Task<bool> MakeCall(string AgentNumber, string CustomNumber)
        {
            if (Connected)
            {
                if (telephony is not null)
                {
                    //return await telephony.MakeBusinessCallAsync(AgentNumber, CustomNumber, "0");
                    return await telephony.MakeCallAsync(AgentNumber, CustomNumber, true, null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }


    }
}
