using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Pieces;

namespace Stratego.Tests
{
    [TestClass]
    public class BoardTest
    {

        [TestMethod]
        public void TestLakesInTheMiddle()
        {
            Board board = new Board();
            board.SetPiece(new Square(5, 5), null);
            board.SetPiece(new Square(6, 6), null);
            board.SetPiece(new Square(2, 5), new Bomb(new Gamer("Pedro")));

            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(3, 5)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(3, 6)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(4, 5)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(4, 6)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(7, 5)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(7, 6)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(8, 5)]);
            Assert.AreEqual(new Lake(), board.BoardSpace[new Square(8, 6)]);

            Assert.AreNotEqual(new Lake(), board.BoardSpace[new Square(5, 5)]);
            Assert.AreNotEqual(new Lake(), board.BoardSpace[new Square(6, 6)]);
            Assert.AreNotEqual(new Lake(), board.BoardSpace[new Square(2, 5)]);
        }
    }
}
