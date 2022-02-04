using GanhouExperienciaIssoSim.Domain;
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
            var LuckyNumbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            var Game = new Game();

            var myGame = Game.ConvertMyGameStringToListInt(game);

            var numberOfRights = Game.GetNumberRights(LuckyNumbers, myGame);

            var message = Game.DidWeWin(numberOfRights);

            Assert.Equal("2022, vc vai trabalhar fdp! tamuh pobre! ", message);
        }

        [Fact]
        public void Should_ReadFileAndConvertInListOfBets()
        {
            var Game = new Game();

            var bets = Game.GetBeats();

            Assert.NotNull(bets);
        }
    }

}