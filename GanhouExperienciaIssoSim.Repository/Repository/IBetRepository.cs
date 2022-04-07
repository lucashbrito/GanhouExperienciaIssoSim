using GanhouExperienciaIssoSim.Domain;

namespace GanhouExperienciaIssoSim.Repository
{
    public interface IBetRepository
    {
        List<Bet> GetAllReadFromFile(string game);
        public Bet Create(Bet bet);
        IList<Bet> Get();
        Bet Find(Guid id);
        void Update(Bet bet);
        void Delete(Guid id);
    }
}
