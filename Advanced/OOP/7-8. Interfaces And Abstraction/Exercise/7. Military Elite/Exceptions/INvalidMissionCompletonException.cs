
using System;

namespace E7MilitaryElite.Exceptions
{
    public class INvalidMissionCompletonException : Exception
    {
        private const string DEF_EXC_MSG = "Mission Already completed!";
        public INvalidMissionCompletonException() : base(DEF_EXC_MSG)
        {
        }

        public INvalidMissionCompletonException(string message) : base(message)
        {
        }
    }
}
