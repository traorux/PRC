using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PRC.CORE.Media.Call.Types;
using o2g;
using o2g.Utility;
using PRC.CORE.Media.Call;
using System;
using System.Threading.Tasks;
using static o2g.O2G;
using static System.Net.Mime.MediaTypeNames;

namespace PRC.MEDIA.OXE
{
    public class MediaOXE : IMediaCall
    {
        

        private string myLoginName = "oxe890";
        private string myPassword = "0000";
        private O2G.Application myApplication; 

        private ITelephony telephony;
        private bool Connected = false;
        private readonly string Host_o2G;
        private readonly ILogger<MediaOXE> logger;

        public event Action<string> ReceivedCall;

        public MediaOXE(ILogger<MediaOXE> logger, IConfiguration Config)
        {
            HttpClientBuilder.DisableSSValidation = true;
            HttpClientBuilder.TraceREST = true;
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



        public Task<bool> MakeCallAsync(string AgentNumber, string CustomNumber)
        {
            return this.MakeCallAsync(AgentNumber, CustomNumber, true, false, null, null, null);
        }


        public async Task<bool> MakeCallAsync(string AgentNumber, string CustomNumber, bool autoAnswer = true, bool inhibitProgressTone = false, string associatedData = null, string callingNumber = null, string loginName = null)
        {
            if (Connected)
            {
                if (telephony is not null)
                {

                    return await telephony.MakeCallAsync(AgentNumber, CustomNumber, true, false, null, null, null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> BasicMakeCallAsync(string AgentNumber, string CustomNumber)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.BasicMakeCallAsync(AgentNumber, CustomNumber, true);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> BasicAnswerCallAsync(string AgentNumber)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.BasicAnswerCallAsync(AgentNumber);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        //public async Task<bool> GetCallsAsync(string loginName)
        //{
        //    if (Connected)
        //    {

        //        if (telephony is not null)
        //        {

        //            return await telephony.GetCallsAsync(loginName);
        //        }
        //    }
        //    else
        //    {
        //        await EventRegister();
        //    }
        //    return false;
        //}

        //public async Task<bool> GetCallAsync(string callRef, string loginName)
        //{
        //    if (Connected)
        //    {

        //        if (telephony is not null)
        //        {

        //            return await telephony.GetCallAsync(callRef, loginName);
        //        }
        //    }
        //    else
        //    {
        //        await EventRegister();
        //    }
        //    return false;
        //}

        public async Task<bool> BasicDropMeAsync(string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.BasicDropMeAsync(loginName);
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
