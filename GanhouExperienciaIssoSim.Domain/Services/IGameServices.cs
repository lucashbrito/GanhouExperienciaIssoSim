namespace GanhouExperienciaIssoSim.Domain.Services
{
    public interface IGameServices
    {
        void RunConsole();
        List<Bet> VerifyBets(string drawnNumbers, string name);
        List<Bet> GetBets();
    }
}
