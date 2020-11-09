
using System.Collections.Generic;

namespace E7MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }


        void AddRepair(IRepair repair);

    }
}
