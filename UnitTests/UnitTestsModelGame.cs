using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    /// <summary>
    /// Модульное тестирование класса ModelGame.
    /// </summary>
    [TestClass]
    public class UnitTestsModelGame
    {
        /// <summary>
        /// Тест создания игрока
        /// </summary>
        [TestMethod]
        public void CreatingTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока на 1 клетку вверх
        /// </summary>
        [TestMethod]
        public void MovingUpTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("up");
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 1);
        }

        /// <summary>
        /// Тест перемещения игрока на 1 клетку вниз
        /// </summary>
        [TestMethod]
        public void MovingDownTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("down");
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 3);
        }

        /// <summary>
        /// Тест перемещения игрока на 1 клетку влево
        /// </summary>
        [TestMethod]
        public void MovingLeftTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("left");
            Assert.AreEqual(model.Hero.X, 1);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока на 1 клетку вправо
        /// </summary>
        [TestMethod]
        public void MovingRightTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("right");
            Assert.AreEqual(model.Hero.X, 3);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока на 1 клетку вправо разным регистром
        /// </summary>
        [TestMethod]
        public void MovingRightDifferentRegisterTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("RiGhT");
            Assert.AreEqual(model.Hero.X, 3);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока на null
        /// </summary>
        [TestMethod]
        public void MovingNullTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero(null);
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока - пустая строка
        /// </summary>
        [TestMethod]
        public void MovingEmptyTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("");
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест перемещения игрока - строка пробелов
        /// </summary>
        [TestMethod]
        public void MovingSpacesTest()
        {
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.MoveHero("    ");
            Assert.AreEqual(model.Hero.X, 2);
            Assert.AreEqual(model.Hero.Y, 2);
        }

        /// <summary>
        /// Тест события выигрыша
        /// </summary>
        [TestMethod]
        public void WinningTest()
        {
            bool isWon = false;
            ModelGame model = new ModelGame();
            model.CreateGameField();
            model.GameWin += new ModelGame.dEventHandler(()=> { isWon = true; });
            model.MoveHero("right");
            Assert.IsTrue(isWon);
        }
    }
}
