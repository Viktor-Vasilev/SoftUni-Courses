

using System.Collections.Generic;

namespace E7MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }


        void AddMission(IMission mission);
    }
}
