using GanhouExperienciaIssoSim.Domain;
using GanhouExperienciaIssoSim.Domain.Common;
using GanhouExperienciaIssoSim.Repository;
using System.Collections.Generic;
using Xunit;

namespace GanhouExperienciaIssoSimTest
{
    public class GameTest
    {
        [Theory]
        [InlineData("12,23,45,6,7,8")]
        public void Should_ReadGameAndKeepYouPoor(string game)
        {
            var LuckyNumbers = new PrizeDraw(new List<int>() { 1, 2, 3, 4, 5, 6 }, "2450");

            var myGame = game.ConvertMyGameStringToListInt();

            (int hits, List<int> righHits) = LuckyNumbers.GetHits(myGame);

            Assert.Equal(1, hits);
        }

        [Fact]
        public void Should_ReadFileAndConvertInListOfBets()
        {
            var betRepository = new BetRepository();

            var bets = betRepository.GetAllReadFromFile("");

            Assert.NotNull(bets);
        }
    }

}