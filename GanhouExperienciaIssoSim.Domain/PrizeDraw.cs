namespace GanhouExperienciaIssoSim.Domain
{
    public class PrizeDraw
    {
        public PrizeDraw(List<int> luckNumbers, string? name)
        {
            Numbers = luckNumbers;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<int> Numbers { get; set; }

        public int GetNumberRights(List<int> myGame)
        {
            var numberOfrights = 0;
            var rightNumbers = new List<int>();

            foreach (var luckNumber in Numbers)
            {
                foreach (var myNumber in myGame)
                {
                    if (luckNumber == myNumber)
                    {
                        numberOfrights++;
                        rightNumbers.Add(myNumber);
                    }
                }
            }

            PrintNumbers(myGame, rightNumbers);

            return numberOfrights;
        }

        private static void PrintNumbers(List<int> myGame, List<int> rightNumbers)
        {
            PrintRightNumbers(myGame, rightNumbers);

            PrintWrongNumbers(myGame);

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintWrongNumbers(List<int> myGame)
        {
            foreach (var myNumber in myGame)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0},", myNumber);
            }
        }

        private static void PrintRightNumbers(List<int> myGame, List<int> rightNumbers)
        {
            foreach (var myNumber in myGame.ToList())
            {
                foreach (var rightNumber in rightNumbers.ToList())
                {
                    if (rightNumber == myNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0},", myNumber);
                        myGame.Remove(myNumber);
                        rightNumbers.Remove(myNumber);
                    }
                }
            }
        }

    }
}
