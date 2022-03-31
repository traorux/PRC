using PRC.CORE.Media.Call.Types.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class OnUserStateModifiedEvent
    {
        public String LoginName;
        public UserState State;
    }
}
