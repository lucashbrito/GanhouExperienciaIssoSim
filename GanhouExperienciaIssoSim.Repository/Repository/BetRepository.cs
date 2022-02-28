using GanhouExperienciaIssoSim.Domain;
using MongoDB.Driver;

namespace GanhouExperienciaIssoSim.Repository
{
    public class BetRepository : IBetRepository
    {
        IMongoCollection<Bet> _Bets;
        public BetRepository()
        {
            var dbClient = new MongoClient("mongodb+srv://lucashbrito1:JoaoCarlos567@googlecluster0.pfsi6.mongodb.net/GanhouSim?retryWrites=true&w=majority");

            var database = dbClient.GetDatabase("GanhouSim");
            _Bets = database.GetCollection<Bet>("Bets");

        }

        public List<Bet> GetAllReadFromFile()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Lucas Brito\source\repos\GanhouExperienciaIssoSim\GanhouExperienciaIssoSim\Bets.txt");

            var beats = new List<Bet>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Aposta efetivada!"))
                {
                    var beat = new Bet();
                    i++;

                    if (i < lines.Length)
                        beat.PrizeDrawName = lines[i];

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

        public Bet Create(Bet submission)
        {
            _Bets.InsertOne(submission);
            return submission;
        }

        public IList<Bet> Get() =>
            _Bets.Find(sub => true).ToList();

        public Bet Find(Guid id) =>
            _Bets.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Bet submission) =>
            _Bets.ReplaceOne(sub => sub.Id == submission.Id, submission);

        public void Delete(Guid id) =>
            _Bets.DeleteOne(sub => sub.Id == id);
    }
}
