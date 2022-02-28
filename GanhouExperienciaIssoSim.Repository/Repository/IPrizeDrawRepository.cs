using GanhouExperienciaIssoSim.Domain;

namespace GanhouExperienciaIssoSim.Repository
{
    public interface IPrizeDrawRepository
    {
        List<PrizeDraw> GetAllReadFromFile();
        public PrizeDraw Create(Bet bet);
        IList<PrizeDraw> Get();
        Bet Find(Guid id);
        void Update(PrizeDraw bet);
        void Delete(PrizeDraw id);
    }
}
