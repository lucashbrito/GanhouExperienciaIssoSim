using GanhouExperienciaIssoSim.Domain;

namespace GanhouExperienciaIssoSim.Services
{
    public interface IGameServices
    {
        void RunConsole();
        List<Bet> VerifyBets(string drawnNumbers, string name);
        List<Bet> GetBets();
        public Bet Create(Bet bet);
        IList<Bet> Get();
        Bet Find(Guid id);
        void Update(Bet bet);
        void Delete(Guid id);
    }
}
