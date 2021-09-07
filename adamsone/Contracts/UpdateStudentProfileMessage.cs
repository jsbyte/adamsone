using System;

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
