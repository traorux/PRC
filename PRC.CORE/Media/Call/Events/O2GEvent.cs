using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class O2GEventArgs<T> : EventArgs where T : O2GEvent
    {
        public O2GEventArgs(T ev)
        {
            Event = ev;
        }
        public T Event { get; init; }
    }
    public class O2GEvent
    {
        public string EventName { get; init; }
    }
}
