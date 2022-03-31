using PRC.CORE.Media.Call.Types.Call;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types
{
    public class CallCapabilities
    {
        public bool AddDevice { get; init; }
        public bool AddParticipant { get; init; }
        public bool Intruded { get; init; }
        public bool Transfer { get; init; }
        public bool BlindTransfer { get; init; }
        public bool Merge { get; init; }
        public bool Redirect { get; init; }
        public bool PickedUp { get; init; }
        public bool RedirectToVoiceMail { get; init; }
        public bool OverflowToVoiceMail { get; init; }
        public bool DropMe { get; init; }
        public bool Terminate { get; init; }
        public bool Reject { get; init; }
        public bool CallBack { get; init; }
        public bool Park { get; init; }
        public bool StartRecord { get; init; }
        public bool StopRecord { get; init; }
        public bool PauseRecord { get; init; }
        public bool ResumeRecord { get; init; }
        public bool DropParticipant { get; init; }
        public bool MuteParticipant { get; init; }
        public bool HoldParticipant { get; init; }
    }
    public class PbxCall
    {
        public string CallRef { get; init; }
        public CallData CallData { get; init; }
        public List<Leg> Legs { get; init; }
        public List<Participant> Participants { get; init; }
    }
}
