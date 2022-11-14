using PRC.CORE.Media.Call.Events;
using PRC.CORE.Media.Call.Types;
using PRC.CORE.Media.Call.Types.Call;
using PRC.CORE.Media.Call.Types.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRC.CORE.Media.Call
{
    public interface IMediaCall
    {

        public event Action<PRC.CORE.Model.Call, ContextAppels> CallEvent;

        Task EventRegister();
        Task<bool> BasicMakeCallAsync(string AgentNumber, string CustomNumber);
        Task<bool> BasicAnswerCallAsync(string AgentNumber);
        Task<bool> MakeCallAsync(string AgentNumber, string CustomNumber);
        Task<bool> MakeCallAsync(string AgentNumber, string CustomNumber, bool autoAnswer = true, bool inhibitProgressTone = false, string associatedData = null, string callingNumber = null, string loginName = null);
        Task<bool> AnswerAsync(string callRef, string deviceId);
        Task<bool> BasicDropMeAsync(string loginName = null);
        Task<bool> HoldAsync(string callRef, string deviceId, string loginName = null);
        Task<bool> RetrieveAsync(string callRef, string deviceId, string loginName = null);

        //Task<List<PbxCall>> GetCallsAsync(string loginName = null); 
        //Task<PbxCall> GetCallAsync(string callRef, string loginName = null);

        //Task<bool> MakePrivateCallAsync(string deviceId, string callee, string pin, string secretCode = null, string loginName = null);
        //Task<bool> MakeBusinessCallAsync(string deviceId, string callee, string businessCode, string loginName = null);
        //Task<bool> MakeSupervisorCallAsync(string deviceId, bool autoAnswer = true, string loginName = null);
        //Task<bool> AlternateAsync(string callRef, string deviceId);
        //Task<bool> AttachDataAsync(string callRef, string deviceId, string associatedData);
        //Task<bool> BlindTransferAsync(string callRef, string transferTo, bool anonymous = false, string loginName = null);
        //Task<bool> CallbackAsync(string callRef, string loginName = null);
        //Task<bool> DropmeAsync(string callRef, string loginName = null);
        //Task<bool> HoldAsync(string callRef, string deviceId, string loginName = null);
        //Task<bool> MergeAsync(string callRef, string heldCallRef, string loginName = null);
        //Task<bool> OverflowToVoiceMailAsync(string callRef, string loginName = null);
        ////Task<TelephonicState> GetStateAsync(string loginName = null);
        //Task<bool> ParkAsync(string callRef, string parkTo = null, string loginName = null);
        ////Task<List<Participant>> GetParticipantsAsync(string callRef, string loginName = null);
        ////Task<Participant> GetParticipantAsync(string callRef, string participantId, string loginName = null);
        //Task<bool> DropParticipantAsync(string callRef, string participantId, string loginName = null);
        //Task<bool> ReconnectAsync(string callRef, string deviceId, string enquiryCallRef, string loginName = null);
        ////Task<bool> RecordingAsync(string callRef, RecordingAction action, string loginName = null);
        //Task<bool> RedirectAsync(string callRef, string redirectTo, bool anonymous = false, string loginName = null);
        //Task<bool> RetrieveAsync(string callRef, string deviceId, string loginName = null);
        //Task<bool> SendDtmfAsync(string callRef, string deviceId, string number);
        //Task<bool> SendAccountInfoAsync(string callRef, string deviceId, string accountInfo);
        //Task<bool> TransferAsync(string callRef, string heldCallRef, string loginName = null);
        //Task<bool> DeskSharingLogOnAsync(string dssDeviceNumber, string loginName = null);
        //Task<bool> DeskSharingLogOffAsync(string loginName = null);
        ////Task<List<DeviceState>> GetDevicesStateAsync(string loginName = null);
        ////Task<DeviceState> GetDeviceStateAsync(string deviceId, string loginName = null);
        //Task<bool> PickUpAsync(string deviceId, string otherCallRef, string otherPhoneNumber, bool autoAnswer = false);
        //Task<bool> IntrusionAsync(string deviceId);
        //Task<bool> UnParkAsync(string deviceId, string heldCallRef);
        ////Task<HuntingGroupStatus> GetHuntingGroupStatusAsync(string loginName = null);
        //Task<bool> HuntingGroupLogOnAsync(string loginName = null);
        //Task<bool> HuntingGroupLogOffAsync(string loginName = null);
        //Task<bool> AddHuntingGroupMemberAsync(string hgNumber, string loginName = null);
        //Task<bool> DeleteHuntingGroupMemberAsync(string hgNumber, string loginName = null);
        ////Task<HuntingGroups> QueryHuntingGroupsAsync(string loginName = null);
        ////Task<List<Callback>> GetCallbacksAsync(string loginName = null);
        //Task<bool> DeleteCallbacksAsync(string loginName = null);
        ////Task<MiniMessage> GetMiniMessageAsync(string loginName = null);
        //Task<bool> SendMiniMessageAsync(string recipient, string message, string loginName = null);
        //Task<bool> RequestCallbackAsync(string callee, string loginName = null);
        //Task<bool> RequestSnapshotAsync(string loginName = null);
    }
}
