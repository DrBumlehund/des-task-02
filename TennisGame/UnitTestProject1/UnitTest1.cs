using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using TennisGame;

    [TestClass]
    public class UnitTest1
    {
        Player _player1;
        Player _player2;
        TennisGame _game;

        [TestInitialize]
        public void Initialize()
        {
            _player1 = new Player();
            _player2 = new Player();
            _game = new TennisGame(_player1, _player2);
        }
        #region player stuff
        [TestMethod]
        public void TestIncrementScore()
        {
            _player1.IncrementPoints();
            Assert.AreEqual(1, _player1.GetPoints());
        }

        [TestMethod]
        public void TestPointsAfterCreation()
        {
            Assert.AreEqual(0, _player1.GetPoints());
        }
        #endregion

        #region game stuff
        [TestMethod]
        public void TestScoreBeforeGame()
        {
            Assert.AreEqual("love:love", _game.GetScore());
        }

        [TestMethod]
        public void TestScoreAfterOnePoint()
        {
            _player1.IncrementPoints();
            Assert.AreEqual("15:love", _game.GetScore());
        }

        [TestMethod]
        public void TestDeuce()
        {
            for (int i = 0; i<3; i++)
            {
                _player1.IncrementPoints();
                _player2.IncrementPoints();
            }
            Assert.AreEqual("deuce", _game.GetScore());
        }

        [TestMethod]
        public void TestAdvantage()
        {
            for (int i = 0; i < 3; i++)
            {
                _player1.IncrementPoints();
                _player2.IncrementPoints();
            }
            _player1.IncrementPoints();

            Assert.AreEqual("Advantage player1", _game.GetScore());
        }

        [TestMethod]
        public void TestGameWon()
        {
            for (int i = 0; i < 4; i++)
            {
                _player1.IncrementPoints();
            }
            Assert.AreEqual("game player1", _game.GetScore());
        }

        #endregion
    }
}
