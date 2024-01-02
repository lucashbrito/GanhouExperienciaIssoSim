using GanhouExperienciaIssoSim.Domain;
using GanhouExperienciaIssoSim.Domain.Common;
using GanhouExperienciaIssoSim.Repository;

namespace GanhouExperienciaIssoSim.Services
{
    public class GameServices : IGameServices
    {
        public IBetRepository BetRepository { get; set; }

        public GameServices(IBetRepository betRepository)
        {
            BetRepository = betRepository;
        }
        public GameServices()
        {

        }

        #region Console
        public void RunConsole()
        {
            Console.WriteLine("Digite os 6 Numeros sorteados");

            var luckNumbersString = Console.ReadLine();

            var luckNumbers = luckNumbersString.ConvertMyGameStringToListInt();

            Console.WriteLine("nome do sorteio");

            var name = Console.ReadLine();

            var prizeDraw = new PrizeDraw(luckNumbers, name);

            var betRepository = new BetRepository();

            var bets = betRepository.GetAllReadFromFile(name);

            VerifyBetsConsole(prizeDraw, bets);
        }

        private void VerifyBetsConsole(PrizeDraw luckNumbers, List<Bet> bets)
        {
            var numeroDoJogo = 1;

            foreach (var bet in bets)
            {
                Console.WriteLine($"Conferindo Jogo Numero {numeroDoJogo}");

                bet.SetHits(luckNumbers.GetNumberRightsConsole(bet.Numbers));

                SetConsoleColorBasedOnHits(bet.Hits);

                Console.WriteLine($" Acertos:{bet.Hits}");

                numeroDoJogo++;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Juntei todos os jogos {bets.Count}, acertamos todos os numeros sorteado? {CheckIfAllNumbersCovered(bets, luckNumbers)}"); ;
        }
        private void SetConsoleColorBasedOnHits(int hits)
        {
            Console.ForegroundColor = hits > 5 ? ConsoleColor.Green : ConsoleColor.Red;
        }

        #endregion

        public bool CheckIfAllNumbersCovered(List<Bet> bets, PrizeDraw luckNumbers)
        {
            HashSet<int> allBetNumbers = new HashSet<int>();


            foreach (var bet in bets)
            {
                foreach (var number in bet.Numbers)
                {
                    allBetNumbers.Add(number);
                }
            }

            foreach (var number in luckNumbers.NumbersDraws)
            {
                if (!allBetNumbers.Contains(number))
                {
                    return false;
                }
            }

            return true;
        }

        public List<Bet> VerifyBets(string drawnNumbers, string name)
        {
            var luckNumbers = drawnNumbers.ConvertMyGameStringToListInt();

            var prizeDraw = new PrizeDraw(luckNumbers, name);

            var bets = BetRepository.GetAllReadFromFile(name);

            VerifyBets(prizeDraw, bets);

            return bets;
        }

        public List<Bet> GetBets()
        {
            return BetRepository.GetAllReadFromFile(null);
        }

        private void VerifyBets(PrizeDraw prizeDraw, List<Bet> bets)
        {
            foreach (var bet in bets)
            {
                (int hits, List<int> rightHits) = prizeDraw.GetHits(bet.Numbers);

                bet.SetHits(hits);

                bet.SetRightHits(rightHits);
            }
        }

        public Bet Create(Bet bet)
        {
            return BetRepository.Create(bet);
        }

        public IList<Bet> Get()
        {
            return BetRepository.Get();
        }

        public Bet Find(Guid id)
        {
            return BetRepository.Find(id);
        }

        public void Update(Bet bet)
        {
            BetRepository.Update(bet);
        }

        public void Delete(Guid id)
        {
            BetRepository.Delete(id);
        }
    }
}
