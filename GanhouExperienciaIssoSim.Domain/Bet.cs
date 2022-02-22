namespace GanhouExperienciaIssoSim.Domain
{
    public class Bet
    {
        public Guid Id { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
        public int NumbersOfRights { get; set; }
        public string PrizeDrawName { get; set; }
    }
}