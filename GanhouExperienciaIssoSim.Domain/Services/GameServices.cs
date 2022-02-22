using GanhouExperienciaIssoSim.Domain.Common;
using GanhouExperienciaIssoSim.Domain.Repository;

namespace GanhouExperienciaIssoSim.Domain.Services
{
    public class GameServices
    {
        public void Run()
        {
            Console.WriteLine("Digite os 6 Numeros sorteados");

            var luckNumbersString = Console.ReadLine();

            var luckNumbers = luckNumbersString.ConvertMyGameStringToListInt();

            Console.WriteLine("nome do sorteio");

            var name = Console.ReadLine();

            var prizeDraw = new PrizeDraw(luckNumbers, name);

            var betRepository = new BetRepository();

            var bets = betRepository.GetBets();

            VerifyBets(prizeDraw, bets);
        }

        private void VerifyBets(PrizeDraw luckNumbers, List<Bet> bets)
        {
            var numeroDoJogo = 1;

            foreach (var beat in bets)
            {
                Console.WriteLine($"Conferindo Jogo Numero {numeroDoJogo}");

                beat.NumbersOfRights = luckNumbers.GetNumberRights(beat.Numbers);

                if (beat.NumbersOfRights > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($" Acertos:{beat.NumbersOfRights}");

                numeroDoJogo++;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }     
    }
}
