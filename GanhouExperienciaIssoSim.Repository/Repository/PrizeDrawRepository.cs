using GanhouExperienciaIssoSim.Domain;
using MongoDB.Driver;

namespace GanhouExperienciaIssoSim.Repository
{
    public class PrizeDraw : IBetRepository
    {
        IMongoCollection<PrizeDraw> _PrizeDraws;
        public PrizeDraw()
        {
            var dbClient = new MongoClient("mongodb+srv://lucashbrito1:JoaoCarlos567@googlecluster0.pfsi6.mongodb.net/GanhouSim?retryWrites=true&w=majority");

            var database = dbClient.GetDatabase("GanhouSim");
            _PrizeDraws = database.GetCollection<PrizeDraw>("Bets");

        }    
        public PrizeDraw Create(PrizeDraw submission)
        {
            _PrizeDraws.InsertOne(submission);
            return submission;
        }

        public IList<PrizeDraw> Get() =>
            _PrizeDraws.Find(sub => true).ToList();

        public PrizeDraw Find(Guid id) =>
            _PrizeDraws.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(PrizeDraw submission) =>
            _PrizeDraws.ReplaceOne(sub => sub.Id == submission.Id, submission);

        public void Delete(Guid id) =>
            _PrizeDraws.DeleteOne(sub => sub.Id == id);
    }
}
