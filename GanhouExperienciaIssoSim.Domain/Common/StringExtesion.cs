namespace GanhouExperienciaIssoSim.Domain.Common
{
    public static class StringExtesion
    {
        public static List<int> ConvertMyGameStringToListInt(this string game)
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
    }
}
