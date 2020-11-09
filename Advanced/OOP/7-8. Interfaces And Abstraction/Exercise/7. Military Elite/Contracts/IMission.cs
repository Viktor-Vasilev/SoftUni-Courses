
using E7MilitaryElite.Enumerations;

namespace E7MilitaryElite.Contracts
{
    public interface IMission
    {

        string CodeName { get; }

        State State { get; }

        void CompleteMission();


    }
}
