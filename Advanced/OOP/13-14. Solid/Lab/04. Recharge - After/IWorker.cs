using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public interface IWorker
    {

        string Id { get; }
        int WorkingHours { get; }

    }
}
