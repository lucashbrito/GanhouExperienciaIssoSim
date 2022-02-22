namespace GanhouExperienciaIssoSim.Domain.Repository
{
    public class BetRepository : IBetRepository
    {
        public List<Bet> GetBets()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Lucas Brito\source\repos\GanhouExperienciaIssoSim\GanhouExperienciaIssoSim\Bets.txt");

            var beats = new List<Bet>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Aposta efetivada!"))
                {
                    i++;
                    var beat = new Bet();
                    for (int j = 0; j < 6; j++)
                    {
                        i += 1;
                        if (i < lines.Length && int.TryParse(lines[i], out int number))
                            beat.Numbers.Add(number);
                    }
                    if (beat.Numbers.Count == 6)
                        beats.Add(beat);
                }
            }

            return beats;
        }

    }
}
