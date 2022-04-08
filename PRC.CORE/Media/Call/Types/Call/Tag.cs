using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public class Tag
    {
        public string Name { get; init; }
        public string Value { get; init; }
        public List<string> Visibilities { get; init; }
    }
}
