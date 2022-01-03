namespace GanhouExperienciaIssoSim
{
    public class Game
    {
        public void Run()
        {
            Console.WriteLine("Digite os 6 Numeros sorteados");

            var luckNumbersString = Console.ReadLine();

            var luckNumbers = ConvertMyGameStringToListInt(luckNumbersString);

            var beats = GetBeats();

            VerifyBets(luckNumbers, beats);
        }

        private void VerifyBets(List<int> luckNumbers, List<Bet> beats)
        {
            var numeroDoJogo = 1;

            foreach (var beat in beats)
            {
                Console.WriteLine($"Conferindo Jogo Numero {numeroDoJogo}");

                beat.NumbersOfRights = GetNumberRights(luckNumbers, beat.Numbers);

                beat.Numbers.ForEach(i => Console.Write("{0},", i));

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

        public string DidWeWin(int numberOfRights)
        {
            if (numberOfRights == 6)
                return "Mentira, PQP! VTNC! 2022 é nois! BH é NOIS";
            else return "2022, vc vai trabalhar fdp! tamuh pobre! ";
        }

        public int GetNumberRights(List<int> luckyNumbers, List<int> myGame)
        {
            var numberOfrights = 0;

            foreach (var luckNumber in luckyNumbers)
            {
                foreach (var myNumber in myGame)
                {
                    if (luckNumber == myNumber)
                        numberOfrights++;
                }
            }

            return numberOfrights;
        }

        public List<int> ConvertMyGameStringToListInt(string game)
        {
            var myGame = new List<int>();

            var numbersWithDots = game.Split(',');

            foreach (var item in numbersWithDots)
            {
                if (int.TryParse(item, out int number))
                    myGame.Add(number);
            }

            return myGame;
        }

        public List<Bet> GetBeats()
        {          
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Lucas Brito\Documents\Test.txt");


            var beats = new List<Bet>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("2440	Efetivada	R$ 4,50"))
                {
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
