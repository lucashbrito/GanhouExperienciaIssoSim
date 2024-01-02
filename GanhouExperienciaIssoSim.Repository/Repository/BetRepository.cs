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

        public List<Bet> GetAllReadFromFile(string game)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $@"Bets{game}.txt";
            string fullPath = Path.Combine(basePath, relativePath);

            string[] lines = File.ReadAllLines(fullPath);

            var bets = new List<Bet>();

            Bet currentBet = null;

            foreach (var line in lines)
            {
                if (line.Contains("Efetivada"))
                {
                    if (currentBet != null && currentBet.Numbers.Count == 6)
                    {
                        bets.Add(currentBet);
                    }

                    currentBet = new Bet();
                }
                else if (currentBet != null && int.TryParse(line, out int number))
                {
                    currentBet.Numbers.Add(number);
                }
            }

            if (currentBet != null && currentBet.Numbers.Count == 6)
            {
                bets.Add(currentBet);
            }


            return bets;
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
