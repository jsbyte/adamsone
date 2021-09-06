using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamsone.Contracts
{
    public class UpdateStudentProfileMessage
    {
        public TimeSpan Delay { get; set; }

        public UpdateStudentProfileMessage(TimeSpan delay)
        {
            Delay = delay;
        }
    }
}
