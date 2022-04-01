using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using o2g;
using o2g.Types.TelephonyNS.CallNS.AcdNS;
using o2g.Utility;
using PRC.CORE.Media.Call;
using PRC.CORE.Media.Call.Events;
using PRC.CORE.Media.Call.Types;
using PRC.CORE.Media.Call.Types.Call;
using System;
using System.Collections.Generic;
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
        private readonly Action _action;

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

        public async Task<bool> MakePrivateCallAsync(string deviceId, string callee, string pin, string secretCode = null, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.MakePrivateCallAsync(deviceId, callee, pin, secretCode = null, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> MakeBusinessCallAsync(string deviceId, string callee, string businessCode, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.MakeBusinessCallAsync(deviceId, callee, businessCode, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> MakeSupervisorCallAsync(string deviceId, bool autoAnswer = true, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.MakeSupervisorCallAsync(deviceId, autoAnswer = true, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> MakePilotOrRSISupervisedTransferCallAsync(string deviceId, string pilot, string associatedData = null, List<AcrSkill> callProfile = null, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.MakePilotOrRSISupervisedTransferCallAsync(deviceId, pilot, associatedData = null, callProfile = null, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> MakePilotOrRSICallAsync(string deviceId, string pilot, bool autoAnswer = true, string associatedData = null, List<AcrSkill> callProfile = null, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.MakePilotOrRSICallAsync(deviceId, pilot, autoAnswer = true, associatedData = null, callProfile = null, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }

        public async Task<bool> AlternateAsync(string callRef, string deviceId)
        {

            return await telephony.AlternateAsync(callRef, deviceId);
        }

        public async Task<bool> AnswerAsync(string callRef, string deviceId)
        {
            return await telephony.AnswerAsync(callRef, deviceId);
        }

        public async Task<bool> AttachDataAsync(string callRef, string deviceId, string associatedData)
        {
            return await telephony.AttachDataAsync(callRef, deviceId, associatedData);
        }
        public async Task<bool> BlindTransferAsync(string callRef, string transferTo, bool anonymous = false, string loginName = null)
        {
            return await telephony.BlindTransferAsync(callRef, transferTo, anonymous = false, loginName = null);
        }

        public async Task<bool> CallbackAsync(string callRef, string loginName = null)
        {
            return await telephony.CallbackAsync(callRef, loginName = null);
        }

        public async Task<bool> DropmeAsync(string callRef, string loginName = null)
        {
            return await telephony.DropmeAsync(callRef, loginName = null);
        }

        public async Task<bool> BasicDropMeAsync(string loginName = null)
        {
            return await telephony.BasicDropMeAsync(loginName = null);
        }

        public async Task<bool> HoldAsync(string callRef, string deviceId, string loginName = null)
        {
            return await telephony.HoldAsync(callRef, deviceId, loginName = null);
        }

        public async Task<bool> MergeAsync(string callRef, string heldCallRef, string loginName = null)
        {
            return await telephony.MergeAsync(callRef, heldCallRef, loginName = null);
        }

        public async Task<bool> OverflowToVoiceMailAsync(string callRef, string loginName = null)
        {
            return await telephony.OverflowToVoiceMailAsync(callRef, loginName = null);
        }

        public async Task<bool> ParkAsync(string callRef, string parkTo = null, string loginName = null)
        {
            return await telephony.ParkAsync(callRef, parkTo = null, loginName = null);
        }
        public async Task<bool> DropParticipantAsync(string callRef, string participantId, string loginName = null)
        {
            return await telephony.DropParticipantAsync(callRef, participantId, loginName = null);
        }
        public async Task<bool> ReconnectAsync(string callRef, string deviceId, string enquiryCallRef, string loginName = null)
        {
            return await telephony.ReconnectAsync(callRef, deviceId, enquiryCallRef, loginName = null);
        }
        public async Task<bool> RedirectAsync(string callRef, string redirectTo, bool anonymous = false, string loginName = null)
        {
            return await telephony.RedirectAsync(callRef, redirectTo, anonymous = false, loginName = null);
        }
        public async Task<bool> RetrieveAsync(string callRef, string deviceId, string loginName = null)
        {
            return await telephony.RetrieveAsync(callRef, deviceId, loginName = null);
        }
        public async Task<bool> SendDtmfAsync(string callRef, string deviceId, string number)
        {
            return await telephony.SendDtmfAsync(callRef, deviceId, number);
        }
        public async Task<bool> SendAccountInfoAsync(string callRef, string deviceId, string accountInfo)
        {
            return await telephony.SendAccountInfoAsync(callRef, deviceId, accountInfo);
        }
        public async Task<bool> TransferAsync(string callRef, string heldCallRef, string loginName = null)
        {
            if (Connected)
            {

                if (telephony is not null)
                {

                    return await telephony.TransferAsync(callRef, heldCallRef, loginName = null);
                }
            }
            else
            {
                await EventRegister();
            }
            return false;
        }
        public async Task<bool> DeskSharingLogOnAsync(string dssDeviceNumber, string loginName = null)
        {
            return await telephony.DeskSharingLogOnAsync(dssDeviceNumber, loginName = null);
        }
        public async Task<bool> DeskSharingLogOffAsync(string loginName = null)
        {
            return await telephony.DeskSharingLogOffAsync(loginName = null);
        }
        public async Task<bool> PickUpAsync(string deviceId, string otherCallRef, string otherPhoneNumber, bool autoAnswer = false)
        {
            return await telephony.PickUpAsync(deviceId, otherCallRef, otherPhoneNumber, autoAnswer = false);
        }
        public async Task<bool> IntrusionAsync(string deviceId)
        {
            return await telephony.IntrusionAsync(deviceId);
        }
        public async Task<bool> UnParkAsync(string deviceId, string heldCallRef)
        {
            return await telephony.UnParkAsync(deviceId, heldCallRef);
        }
        public async Task<bool> HuntingGroupLogOnAsync(string loginName = null)
        {
            return await telephony.HuntingGroupLogOnAsync(loginName = null);
        }
        public async Task<bool> HuntingGroupLogOffAsync(string loginName = null)
        {
            return await telephony.HuntingGroupLogOffAsync(loginName = null);
        }
        public async Task<bool> AddHuntingGroupMemberAsync(string hgNumber, string loginName = null)
        {
            return await telephony.AddHuntingGroupMemberAsync(hgNumber, loginName = null);
        }
        public async Task<bool> DeleteHuntingGroupMemberAsync(string hgNumber, string loginName = null)
        {
            return await telephony.DeleteHuntingGroupMemberAsync(hgNumber, loginName = null);
        }
        public async Task<bool> DeleteCallbacksAsync(string loginName = null)
        {
            return await telephony.DeleteCallbacksAsync(loginName = null);
        }
        public async Task<bool> SendMiniMessageAsync(string recipient, string message, string loginName = null)
        {
            return await telephony.SendMiniMessageAsync(recipient, message, loginName = null);
        }
        public async Task<bool> RequestCallbackAsync(string callee, string loginName = null)
        {
            return await telephony.RequestCallbackAsync(callee, loginName = null);
        }
        public async Task<bool> RequestSnapshotAsync(string loginName = null)
        {
            return await telephony.RequestSnapshotAsync(loginName = null);
        }
    }
}
