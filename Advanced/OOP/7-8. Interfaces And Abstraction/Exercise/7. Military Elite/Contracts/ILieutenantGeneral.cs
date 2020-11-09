

using System.Collections.Generic;

namespace E7MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);


    }
}
