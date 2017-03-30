using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Pieces;

namespace Stratego.Tests
{
    [TestClass]
    public class GameTest
    {
        private Gamer sasi;
        private Gamer cateto;

        private Game game;
        private Board gameBoard;
        private Piece bomb;
        private Piece marshal;
        private Piece general;
        private Piece coronel;
        private Piece spy;
        private Piece captain;
        private Piece flag;
        private Piece lieutentaium;
        private Piece sergeant;
        private Piece miner;
        private Piece scout;
        private Piece major;

        [TestInitialize()]
        public void Initialize()
        {
            sasi = new Gamer("Sasi");
            cateto = new Gamer("Cateto");

            game = new Game();
            game.SetGamers(sasi, cateto);
            gameBoard = game.GetBoard();
            lieutentaium = new Lieutentaium(sasi);
            sergeant = new Sergeant(sasi);
            marshal = new Marshal(sasi);
            general = new General(sasi);
            captain = new Captain(sasi);
            coronel = new Coronel(sasi);
            miner = new Miner(sasi);
            scout = new Scout(sasi);
            major = new Major(sasi);
            flag = new Flag(sasi);
            bomb = new Bomb(sasi);
            spy = new Spy(sasi);
        }

        [TestMethod]
        public void TestNicknameOfGamers()
        {
            Assert.IsTrue(game.SetGamers(sasi, cateto));

            String newNickname = "nombre";

            sasi = new Gamer(newNickname);
            cateto = new Gamer(newNickname);
            Game strategoGame = new Game();

            Assert.IsFalse(strategoGame.SetGamers(sasi, cateto));
        }

        [TestMethod]
        public void TestPutPiecesByPlayer()
        {
            Assert.IsTrue(game.SetPieceOn(1, 1, bomb));

            Assert.IsFalse(game.SetPieceOn(11, 1, marshal));

            game.SetPieceOn(2, 1, marshal);
            game.SetPieceOn(3, 1, general);
            game.SetPieceOn(4, 1, coronel);
            game.SetPieceOn(5, 1, coronel);
            game.SetPieceOn(6, 1, major);
            game.SetPieceOn(7, 1, major);
            game.SetPieceOn(8, 1, major);
            game.SetPieceOn(9, 1, captain);
            game.SetPieceOn(10, 1, captain);
            game.SetPieceOn(1, 2, captain);
            game.SetPieceOn(2, 2, captain);
            game.SetPieceOn(3, 2, lieutentaium);
            game.SetPieceOn(4, 2, lieutentaium);
            game.SetPieceOn(5, 2, lieutentaium);
            game.SetPieceOn(6, 2, lieutentaium);
            game.SetPieceOn(7, 2, sergeant);
            game.SetPieceOn(8, 2, sergeant);
            game.SetPieceOn(9, 2, sergeant);
            game.SetPieceOn(10, 2, sergeant);
            game.SetPieceOn(1, 3, miner);
            game.SetPieceOn(2, 3, miner);
            game.SetPieceOn(3, 3, miner);
            game.SetPieceOn(4, 3, miner);
            game.SetPieceOn(5, 3, miner);
            game.SetPieceOn(6, 3, scout);
            game.SetPieceOn(7, 3, scout);
            game.SetPieceOn(8, 3, scout);
            game.SetPieceOn(9, 3, scout);
            game.SetPieceOn(10, 3, scout);
            game.SetPieceOn(1, 4, scout);
            game.SetPieceOn(2, 4, scout);
            game.SetPieceOn(3, 4, scout);
            game.SetPieceOn(4, 4, spy);
            game.SetPieceOn(5, 4, flag);
            game.SetPieceOn(6, 4, bomb);
            game.SetPieceOn(7, 4, bomb);
            game.SetPieceOn(8, 4, bomb);
            game.SetPieceOn(9, 4, bomb);
            game.SetPieceOn(10, 4, bomb);

            Assert.IsFalse(game.SetPieceOn(5, 3, bomb));
        }

        [TestMethod]
        public void TestVerifyFlagQuantity()
        {
            Assert.IsTrue(game.SetPieceOn(1, 4, flag));
            Assert.IsFalse(game.SetPieceOn(20, 4, flag));
        }

        [TestMethod]
        public void TestVerifyMarshalQuantity()
        {
            Assert.IsTrue(game.SetPieceOn(1, 1, marshal));
            Assert.IsFalse(game.SetPieceOn(1, 2, marshal));
        }

        [TestMethod]
        public void TestVerifyBombsQuantit()
        {
            Assert.IsTrue(game.SetPieceOn(1, 1, bomb));
            Assert.IsTrue(game.SetPieceOn(10, 3, bomb));
            Assert.IsTrue(game.SetPieceOn(6, 3, bomb));
            Assert.IsTrue(game.SetPieceOn(1, 4, bomb));
            Assert.IsTrue(game.SetPieceOn(6, 2, bomb));
            Assert.IsTrue(game.SetPieceOn(4, 1, bomb));
            Assert.IsFalse(game.SetPieceOn(1, 2, bomb));
        }

        [TestMethod]
        public void TestVerifyGamerOponentPosition()
        {
            Assert.IsTrue(game.SetPieceOn(5, 4, spy));
            Assert.IsFalse(game.SetPieceOn(5, 8, flag));
        }

        [TestMethod]
        public void TestVerifyGameIsFinishWhenFlagIsCaptured()
        {
            Piece flagOpposite = new Flag(cateto);
            Assert.IsTrue(game.SetPieceOn(2, 4, marshal));
            gameBoard.SetPiece(new Square(2, 5), null);
            gameBoard.SetPiece(new Square(2, 6), null);
            gameBoard.SetPiece(new Square(2, 7), null);
            Assert.IsTrue(game.SetPieceOn(2, 8, flagOpposite));

            gameBoard.MovePiece(new Square(2, 4), new Square(2, 5));
            gameBoard.MovePiece(new Square(2, 5), new Square(2, 6));
            gameBoard.MovePiece(new Square(2, 6), new Square(2, 7));
            
            gameBoard.AttackPiece(new Square(2, 7), new Square(2, 8));
            Assert.IsTrue(gameBoard.IsFinish);
        }

        [TestMethod]
        public void TestVerifyWiner()
        {
            Piece flagOpposite = new Flag(cateto);

            Assert.IsTrue(game.SetPieceOn(2, 4, marshal));
            Assert.IsTrue(gameBoard.SetPiece(new Square(2, 5), null));
            Assert.IsTrue(gameBoard.SetPiece(new Square(2, 6), null));
            Assert.IsTrue(gameBoard.SetPiece(new Square(2, 7), null));
            Assert.IsTrue(game.SetPieceOn(2, 8, flagOpposite));

            gameBoard.MovePiece(new Square(2, 4), new Square(2, 5));
            gameBoard.MovePiece(new Square(2, 5), new Square(2, 6));
            gameBoard.MovePiece(new Square(2, 6), new Square(2, 7));

            Square attacker = new Square(2, 7);
            Square attacked = new Square(2, 8);
            gameBoard.AttackPiece(attacker, attacked);

            Assert.IsTrue(gameBoard.IsFinish);
            Assert.AreEqual(sasi, gameBoard.Winner);
        }
    }
}
