using GanhouExperienciaIssoSim.Domain;

namespace GanhouExperienciaIssoSim.Repository
{
    public interface IPrizeDrawRepository
    {
        public PrizeDraw Create(PrizeDraw bet);
        IList<PrizeDraw> Get();
        PrizeDraw Find(Guid id);
        void Update(PrizeDraw bet);
        void Delete(Guid id);
    }
}
