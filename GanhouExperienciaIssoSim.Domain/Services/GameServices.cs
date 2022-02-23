﻿using GanhouExperienciaIssoSim.Domain.Common;
using GanhouExperienciaIssoSim.Domain.Repository;

namespace GanhouExperienciaIssoSim.Domain.Services
{
    public class GameServices : IGameServices
    {
        public IBetRepository BetRepository { get; set; }

        public GameServices(IBetRepository betRepository)
        {
            BetRepository = betRepository;
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

            var bets = betRepository.GetBets();

            VerifyBetsConsole(prizeDraw, bets);
        }

        private void VerifyBetsConsole(PrizeDraw luckNumbers, List<Bet> bets)
        {
            var numeroDoJogo = 1;

            foreach (var bet in bets)
            {
                Console.WriteLine($"Conferindo Jogo Numero {numeroDoJogo}");

                bet.SetHits(luckNumbers.GetNumberRightsConsole(bet.Numbers));

                if (bet.Hits > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($" Acertos:{bet.Hits}");

                numeroDoJogo++;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion

        public List<Bet> VerifyBets(string drawnNumbers, string name)
        {
            var luckNumbers = drawnNumbers.ConvertMyGameStringToListInt();

            var prizeDraw = new PrizeDraw(luckNumbers, name);

            var bets = BetRepository.GetBets();

            VerifyBets(prizeDraw, bets);

            return bets;
        }

        public List<Bet> GetBets()
        {
            return BetRepository.GetBets();
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
    }
}
